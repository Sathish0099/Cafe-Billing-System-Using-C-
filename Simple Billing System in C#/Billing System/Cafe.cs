using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement
{
    class Cafe
    {

        //Default Constructor
        public Cafe()
        {
            newlatteeCof = 0.0;
            newmochaCof = 0.0;
            newespresso = 0.0;
            newvaleCof = 0.0;
            newcappucino = 0.0;
            newafricanCof = 0.0;
            newmilkTea = 0.0;
            newchineseTea = 0.0;

            newcofCake = 0.0;
            newredValvet = 0.0;
            newbForest = 0.0;
            newbostonCream = 0.0;
            newlagosChoco = 0.0;
            newkilbChoco = 0.0;
            newcheeseCak = 0.0;
            newrainbow = 0.0;
        }

        //Set Method
        public Cafe(double latteeCof,double mochaCof,double espresso,double valeCof, double cappucino,double africanCof,double milkTea,double chineseTea,
                  double cofCake,double redValvet,double bForest,double bostonCream, double lagosChoco, double kilbChoco,double cheeseCak,double rainbow)
        {
            newlatteeCof = latteeCof;
            newmochaCof = mochaCof;
            newespresso = espresso;
            newvaleCof = valeCof;
            newcappucino = cappucino;
            newafricanCof = africanCof;
            newmilkTea = milkTea;
            newchineseTea = chineseTea;

            newcofCake = cofCake;
            newredValvet = redValvet;
            newbForest = bForest;
            newbostonCream = bostonCream;
            newlagosChoco = lagosChoco;
            newkilbChoco = kilbChoco;
            newcheeseCak = cheeseCak;
            newrainbow = rainbow;    

        }

        //get Method
        public double getLatteCof() { return newlatteeCof; }
        public double getMochaCof() { return newmochaCof; }
        public double getEspresCof() { return newespresso; }
        public double getValeCof() { return newvaleCof; }
        public double getCappCof() { return newcappucino; }
        public double getAfriCof() { return newafricanCof; }
        public double getMilkTea() { return newmilkTea; }
        public double getChineseTea() { return newchineseTea; }
        public double getCoffCake() { return newcofCake; }
        public double getRedValCake() { return newredValvet; }
        public double getBlForCake() { return newbForest; }
        public double getBosCreamCake() { return newbostonCream; }
        public double getLagosChocoCake() { return newlagosChoco; }
        public double getKilBunCake() { return newkilbChoco; }
        public double getCheCake() { return newcheeseCak; }
        public double getRainCake() { return newrainbow; }


        //Coffee
        private double newlatteeCof;
        private double newmochaCof;
        private double newespresso;
        private double newvaleCof;
        private double newcappucino;
        private double newafricanCof;
        private double newmilkTea;
        private double newchineseTea;

        //Cakes
        private double newcofCake;
        private double newredValvet;
        private double newbForest;
        private double newbostonCream;
        private double newlagosChoco;
        private double newkilbChoco;
        private double newcheeseCak;
        private double newrainbow;
    }
}
