using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grote_opdracht
{
    class Program
    {
        static void Main(string[] args)
        {
            //test
            string[] afstanden_io = System.IO.File.ReadAllLines(@"F:\docu\drive\opti\groot\AfstandenMatrix.txt");
            string[] order_io= System.IO.File.ReadAllLines(@"F:\docu\drive\opti\groot\Orderbestand.txt");
            IEnumerable<string> orders_st = order_io.Skip(1);
            IEnumerable<string> afstanden_st = afstanden_io.Skip(1);
            List<order> order_list = new List<order>();
            Dictionary<Int32, order> orders = new Dictionary<Int32, order>();

            foreach (string ding in orders_st)
            {
                string[] dingen = ding.Split(';');
                int week = dingen[2][0] - 48;
                order x = new order(dingen[1], week, Int32.Parse(dingen[3]), Int32.Parse(dingen[4]), float.Parse(dingen[5]), Int32.Parse(dingen[6]), Int32.Parse(dingen[7]), Int32.Parse(dingen[8]));
                order_list.Add(x);
            }

            Dictionary<Int32, plaats> afstanden = new Dictionary<Int32, plaats>();
            foreach (string ding in afstanden_st)
            {
                string[] dingen = ding.Split(';');
                int van = Int32.Parse(dingen[0]);
                if (!(afstanden.ContainsKey(van) ))
                {
                    plaats x = new plaats();
                    afstanden.Add(van, x);
                }
                afstanden[van].afst.Add(Int32.Parse(dingen[1]), Int32.Parse(dingen[3]) );
            }
            Console.WriteLine(afstanden[287].afst[0]);
            int yeet = afstanden[287].afst.Values.Min();
            Console.WriteLine(yeet);
            //Console.WriteLine(order_list[0].plaats);
            Console.ReadLine();
        }

        static oplossing r_oplossing()
        {
            vrachtwagen v1 = new vrachtwagen(1);
            vrachtwagen v2 = new vrachtwagen(2);
            v1.locatie = 287;
            v2.locatie = 287;
            v1.vuilnis = 0;
            v2.vuilnis = 0;
            int dag = 1;
            float tijd = 0;
            oplossing ding = new oplossing();
            return ding;
        }

        static oplossing l_oplossing()
        {
            oplossing ding = new oplossing();
            for (int i = 0; i < 5; i++)
            {
                ding.l1[i].Append(287);
                ding.l2[i].Append(287);
            }
            return ding;
        }

        static int score(oplossing ding)
        {

            return 0;
        }
    }

    class order
    {
        public string plaats;
        public int PWK;
        public int aant;
        public int volume;
        public float duur;
        public int MID;
        public int xco;
        public int yco;
        public order(string _plaats, int _PWK, int _aant, int _volume, float _duur, int _MID, int _xco, int _yco)
        {
            plaats = _plaats;
            PWK = _PWK;
            aant = _aant;
            volume = _volume/5;
            duur = _duur;
            MID = _MID;
            xco = _xco;
            yco = _yco;
        }
    }

    class oplossing
    {
        public LinkedList<int>[] l1 = new LinkedList<int>[5];
        public LinkedList<int>[] l2 = new LinkedList<int>[5];
        public oplossing(){
            for (int i = 0; i< 5; i++)
            {
                l1[i] = new LinkedList<int>();
                l2[i] = new LinkedList<int>();
            }
            //l1[0].Append(287);
        }
    }

    class plaats
    {
        public Dictionary<Int32, Int32> afst = new Dictionary<Int32, Int32>();
    }

    class vrachtwagen
    {
        public int locatie;
        public int id;
        public int vuilnis;
        public vrachtwagen(int _id)
        {
            id = _id;
        }
        public void ophalen(int MID)
        {

        }
    }
}
