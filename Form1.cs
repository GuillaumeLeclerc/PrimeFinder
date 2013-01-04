using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace PrimeFinder
{
    public partial class Form1 : Form
    {
        public volatile bool working = false;
        private Thread calculateur;
        AutoResetEvent RunCalculateur = new AutoResetEvent(false);
        private List<long> premiers = new List<long>();
        private List<long>[] P_premiers;
        private List<long>[] P_ToSend;
        int nbThreads;
        private long Cursor=2;
        private const int pas = 1000;
        int nbPrime = 0;
        

        public Form1()
        {
            InitializeComponent();
            labelThread.DataBindings.Add("Text", sliderThread, "Value");
            calculateur = new Thread(TaskCalculateur);
            calculateur.Priority = ThreadPriority.Lowest;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            calculateur.Start();
            Win32.AllocConsole();
            premiers.Add(2);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            working = !working;
            if (!working)
            {
                RunCalculateur.Reset();
                buttonStart.Text = "Start !";
                sliderThread.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                buttonStart.Text = "Stop !";
                sliderThread.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                nbThreads = sliderThread.Value;
                RunCalculateur.Set();
            }

        }

        private void TaskCalculateur()
        {
            while (true)
            {
                RunCalculateur.WaitOne();
                P_premiers = new List<long>[nbThreads];
                P_ToSend = new List<long>[nbThreads];
                DateTime debParall;
                for (int i = 0; i < nbThreads; i++)
                {
                    P_premiers[i] = new List<long>();
                }

                    while (working)
                    {
                        debParall = DateTime.Now;
                        Parallel.For(0, nbThreads, (int i) =>
                        {
                            Console.WriteLine(i + " démarre sur " + (Cursor + i * pas) + "-" + (Cursor + (i + 1) * pas));
                            P_ToSend[i] = new List<long>();
                            P_premiers[i] = Form1.MergeList(P_premiers[i], Extract(P_premiers[i].Count));
                            
                            long début = Cursor + i * pas;
                            long fin_Ex = Cursor + (i + 1) * pas;

                            for (long nb = début; nb < fin_Ex; nb++)
                            {
                                if(IsPrmByList(nb,P_premiers[i]) && IsPrmByList(nb,P_ToSend[i]))
                                {
                                    P_ToSend[i].Add(nb);
                                }
                            }
                            Console.WriteLine(i + " finit sur " + (Cursor + i * pas) + "-" + (Cursor + (i + 1) * pas));
                        });
                        Invoke((MethodInvoker)delegate { labelTime.Text = ((DateTime.Now.Subtract(debParall))).Milliseconds.ToString() + " ms"; });

                        for (int i = 0; i < nbThreads; i++)
                        {
                            foreach (long nb in P_ToSend[i])
                            {
                                bool prime = true;
                                for (int j = P_premiers[i].Count; j < premiers.Count; j++)
                                {
                                    if (nb % premiers[j] == 0)
                                    {
                                        prime = false;
                                    }
                                }
                                if (prime)
                                {
                                    premiers.Add(nb);
                                    nbPrime++;
                                    this.Invoke((MethodInvoker)delegate { 
                                        labelNbFound.Text = nbPrime.ToString();
                                        listViewPrime.Items.Add(nb.ToString());
                                    });
                                }
                            }
                        }
                        Invoke((MethodInvoker)delegate
                        {
                            int ms = DateTime.Now.Subtract(debParall).Milliseconds;
                            decimal dd = (ms * 1000)/(pas*(nbThreads));
                            labelTT.Text = dd.ToString()+"ms";
                        });
                        Cursor += (nbThreads) * pas;
                    }
                Console.WriteLine("Aurevoir");
            }
        }




        public static bool IsPrmByList(long nb, List<long> source)
        {
            foreach (long cible in source)
            {
                if (cible * cible > nb)
                    break;
                else
                {
                    if (nb % cible == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static List<T> MergeList<T>(List<T> firstList, List<T> secondList)
        {
            List<T> mergedList = new List<T>();
            mergedList.InsertRange(0, firstList);
            mergedList.InsertRange(mergedList.Count, secondList);
            return mergedList;
        }

        public List<long> Extract(int debut, List<long> ll = null)
        {
            if (ll == null)
            {
                ll = premiers;
            }
            Object locker = new Object();
            lock (locker)
            {

                List<long> tampon = new List<long>();
                for (int i = debut; i < ll.Count; i++)
                {
                    tampon.Add(ll[i]);
                }
                return tampon;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Thread saver = new Thread(SaveFile);
            saver.Start();
        }

        private void SaveFile()
        {
            Wprogress wnd = new Wprogress("Enregistrement");
            ThreadPool.QueueUserWorkItem(new WaitCallback((object o) => { Application.Run(wnd); }));
            using (FileStream fs = File.Open(saveFileDialog1.FileName, FileMode.Create))
            {
                using (StreamWriter hd = new StreamWriter(fs,Encoding.UTF8))
                {
                    long ct = 0;
                    foreach (long nb in premiers)
                    {
                        ct++;
                        hd.Write(nb.ToString()+ "\r\n");
                        ThreadPool.QueueUserWorkItem(new WaitCallback((object o) => { wnd.Changeprogress(ct / (premiers.Count+1)); }));
                    }
                    hd.Close();
                }
                fs.Close();
            }
            try
            {
                wnd.Invoke((MethodInvoker)delegate { wnd.Dispose(); });
            }
            catch(Exception e){
                wnd.Shown += new EventHandler((object sender, EventArgs erg) => { wnd.Dispose(); });
            }
            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void LoadFile()
        {
            Wprogress wnd = new Wprogress("Chargement");
            ThreadPool.QueueUserWorkItem(new WaitCallback((object o) => { Application.Run(wnd); }));
            nbPrime = 0;
            premiers = new List<long>();
            using (FileStream fs = File.Open(openFileDialog1.FileName, FileMode.Open))
            {
                using (StreamReader hd = new StreamReader(fs, Encoding.UTF8))
                {
                    long nb_lignes = 0;
                    string source;
                    while ((source = hd.ReadLine()) != null)
                        nb_lignes++;

                    hd.BaseStream.Position = 0;
                    int loadw = 1;

                    Invoke((MethodInvoker)delegate
                    {
                        listViewPrime.Items.Clear();
                        long nbl = 0;
                        long nb=0;
                        while ((source = hd.ReadLine())!=null)
                        {
                            nbl++;
                            if (long.TryParse(source, out nb))
                            {
                                nbPrime++;
                                premiers.Add(nb);
                                listViewPrime.Items.Add(nb.ToString());
                                labelNbFound.Text = nbPrime.ToString();
                                Cursor = nb+1;
                                ThreadPool.QueueUserWorkItem(new WaitCallback((object o) => { wnd.Changeprogress( (double)nbl/nb_lignes); }));
                            }
                            if (loadw % 1000 == 0)
                            {
                                Application.DoEvents();
                                loadw = 1;
                            }
                            else
                            {
                                loadw++;
                            }
                        }

                    });
                    hd.Close();
                }
                fs.Close();
            }
            try
            {
                wnd.Invoke((MethodInvoker)delegate { wnd.Dispose(); });
            }
            catch (Exception e)
            {
                wnd.Shown += new EventHandler((object sender, EventArgs erg) => { wnd.Dispose(); });
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((object o) => { LoadFile(); }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nbPrime = 0;
            labelNbFound.Text = "0";
            Cursor = 2;
            premiers = new List<long>();
            listViewPrime.Items.Clear();
        }
    }




    public class Win32
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();
    }
}
