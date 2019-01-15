using System;
using System.Collections.Generic;
using System.Text;

namespace CP1
{
    class Methods
    {
        public static double ME1(double Den, double ID, double OD, double t , double cons)
        {
            return (((Math.PI * (OD * OD - ID * ID)) / (4 * t)) / 1000);
        }
        public static double ME2(double Den, double We, double Wi, double t, double cons)
        {
            return (We / Den / t / (Wi / 1000));
        }
        public static double MI1(double Den, double L, double Wi, double t, double cons)
        {
            return (L * Den * t * (Wi / 1000));
        }
        public static double MI2(double Den, double ID, double OD, double Wi, double cons)
        {
            return (((Math.PI / 4) * Wi * (OD * OD - ID * ID) * (Den)) / (1000000));
        }
        public static double OD1(double Den, double ID, double Wi, double We, double cons)
        {
            return (Math.Sqrt((((We / Den) * 1000000 * 4) / (Wi * Math.PI)) + (ID * ID)));
        }
        public static double OD2(double Den, double ID, double L, double t, double cons)
        {
            return (Math.Sqrt(((4 * L * 1000) / Math.PI) * t + (ID * ID)));
        }
        public static double ID1(double Den, double We, double OD, double Wi, double cons)
        {
            return (Math.Sqrt((OD * OD) - (((We / Den) * 1000000 * 4) / (Wi * Math.PI))));
        }
        public static double ID2(double Den, double L, double OD, double t, double cons)
        {
            return (Math.Sqrt((OD * OD) - ((4 * L * 1000) / Math.PI) * t));
        }
        public static double KA1(double Den, double We, double L, double Wi, double cons)
        {
            return (We / (L * Den * (Wi / 1000)));
        }
        public static double KA2(double Den, double ID, double OD, double L, double cons)
        {
            return (((Math.PI * (OD * OD - ID * ID)) / (4 * L)) / 1000);
        }
        //Film Eklemesi
        public static double FA1(double Den, double ID, double OD, double L, double cons)
        {
            return (((Math.PI * (OD * OD - ID * ID)) / (4 * L)) / 1000);
        }
        public static double FA2(double Den, double ID, double OD, double L, double cons)
        {
            return (((Math.PI * (OD * OD - ID * ID)) / (4 * L)) / 1000);
        }
        public static double FM1(double Den, double ID, double OD, double L, double cons)
        {
            return (((Math.PI * (OD * OD - ID * ID)) / (4 * L)) / 1000);
        }
        public static double FM2(double Den, double ID, double OD, double L, double cons)
        {
            return (((Math.PI * (OD * OD - ID * ID)) / (4 * L)) / 1000);
        }

        // Boyalar
        public static double BO1(double Den, double We, double t, double pt, double co)
        {
            return (We / Den / t / (co / pt));
        }

        public static double BO2(double Den, double We, double t, double pt, double co)
        {
            return (We / Den / t / (co / pt));
        }

        public static double IU(double Den, double H, double L, double cons, double cons2)
        {
            return (Math.Pow((Math.PI * H / (2*L)), 2)) * Math.Pow(10,5);
        }
    }
}
