using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using System.Drawing.Drawing2D; // grafika wektorowa 

 

namespace PaintZahanych45230
{
    public partial class PaintZahanych45230 : Form
    {
        const int mz_Margines = 10;    //wolny (pusty) margines na powierzchni graficznej
        static Random mz_rand = new Random();
        //deklaracje zmiennych referencyjnych
        Graphics mz_Rysownica; //powierzchnia graficzna
        Point mz_PunktStartu = Point.Empty;    //punkt pusty
                                            /*zmienna pomocnicza PunktStartu będzie służyła do kreślenia linii pomiędzy
                                             punktem, w którym była ostatnio mysz, a punktem, gdzie znajduje się
                                             aktualnie mysz*/
                                            //lista ewidencji egzemplarzy figur geometrycznych
        List<Punkt> mz_LFG = new List<Punkt>();

        public PaintZahanych45230()
        {
            InitializeComponent();
            //określenie rozmiarów formularza
            this.Left = 10;
            this.Top = 10;
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.90F);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.7F);
            //lokalizacja formularza będzie określana przez właściwość: Location
            StartPosition = FormStartPosition.Manual;
            //blokada zmiany rozmiarów formularza
            this.SetAutoSizeMode(System.Windows.Forms.AutoSizeMode.GrowAndShrink);
            this.MaximizeBox = false;
            //określenie współrzędnych lewego górnego narożnika dla imgRysownica
            imgRysownica.Location = new Point(30, 60);
            imgRysownica.Width = (int)(this.Width * 0.6F);
            imgRysownica.Height = (int)(this.Height * 0.7F);
            //określenie mz_Koloru tła i obramowania dla imgRysownica
            imgRysownica.BackColor = txtKolorTła.BackColor;
            imgRysownica.BorderStyle = BorderStyle.Fixed3D;

            //utworzenie obiektu mapy bitowej o rozmiarach kontrolki PictureBox
            //(imgRysownica)
            imgRysownica.Image = new Bitmap(imgRysownica.Width, imgRysownica.Height);
            //utworzenie obiektu powierzchni graficznej na bitmapie
            mz_Rysownica = Graphics.FromImage(imgRysownica.Image);
            /*FromImage(...): tworzy egzemplarz klasy Graphics na rzecz obiektu
             graficznego(platformy .NET, czyli obiektów klasy Bitmap lub image),
             który jest przekazywany przez jej parametr i na tym obiekcie będzie
             można kreślić figury geometryczne*/
            //ustawienie w kontrolce ComboBox ciągłego stylu Linii
            cmbStylLinii.SelectedIndex = 4;
        }
        //deklaracja klas
        public class Punkt
        {
            //deklaracja rozmiaru punktu: punkt jest okreslony jako koło
            //o średnicy 10 pikseli
            const int mz_RozmiarPunktu = 10;
            //deklaracja pól klasy, które będą dostępnę w klasach pochodnych
            protected int mz_X;
            protected int mz_Y;
            protected Color mz_Kolor;
            protected DashStyle mz_RodzajLinii;
            protected int mz_Grubość;
            protected decimal mz_Grubość2;
            protected bool mz_Widoczny; // true - gdy widoczny, false - gdy nie!

            //deklaracja konstruktorów klasy Tpunkt
            public Punkt()
            {
                mz_X = 0;
                mz_Y = 0;
                mz_Kolor = Color.Black;
                mz_RodzajLinii = DashStyle.Solid;
                mz_Grubość = 1;
                mz_Widoczny = false;
            }
            public Punkt(int mz_x, int mz_y)
            {
                mz_X = mz_x;
                mz_Y = mz_y;
                mz_Kolor = Color.Black;
                mz_RodzajLinii = DashStyle.Solid;
                mz_Grubość = 1;
                mz_Widoczny = false;
            }
            public Punkt(int mz_X, int mz_Y, Color mz_Kolor, DashStyle mz_RodzajLinii, int mz_Grubość)
            {
                this.mz_X = mz_X;
                this.mz_Y = mz_Y;
                this.mz_Kolor = mz_Kolor;
                this.mz_RodzajLinii = mz_RodzajLinii;
                this.mz_Grubość = mz_Grubość;
                mz_Widoczny = false;
            }
            //deklaracja metod prywatnych
            private void mz_UstawXY(int mz_X, int mz_Y)
            {
                this.mz_X = mz_X;
                this.mz_Y = mz_Y;
            }
            //przeciążenie metody UstawXY(. . .)
            private void mz_UstawXY(Point mz_NowaLokalizacja)
            {
                this.mz_X = mz_NowaLokalizacja.X;
                this.mz_Y = mz_NowaLokalizacja.Y;
            }
            //deklaracja metod publicznych
            public void mz_PrzesuńDoNowegoXY(Control mz_Kontrolka,
                           Graphics mz_PowierzchniaGraficzna, int mz_x, int mz_y)
            {
                mz_Wymaż(mz_Kontrolka, mz_PowierzchniaGraficzna);
                mz_UstawXY(mz_x, mz_y);
                mz_Wykreśl(mz_PowierzchniaGraficzna);
            }
            public void mz_FormatujFG(Color mz_Kolor, DashStyle mz_RodzajLinii,
                int mz_Grubość, decimal mz_Grubość2)
            {
                this.mz_Kolor = mz_Kolor;
                this.mz_RodzajLinii = mz_RodzajLinii;
                this.mz_Grubość = mz_Grubość;
                this.mz_Grubość2 = mz_Grubość2; 
            }
            //deklaracja metod wirtualnych, które będą napisywane w klasach pochodnych
            public virtual void mz_Wykreśl(Graphics mz_PowierzchniaGraficzna)
            {

                //wykreslenie punktu jako wypełnionego okręgu
                SolidBrush mz_Pędzel = new SolidBrush(this.mz_Kolor);
                mz_PowierzchniaGraficzna.FillEllipse(mz_Pędzel, mz_X - mz_RozmiarPunktu / 2,
                    mz_Y - mz_RozmiarPunktu / 2, mz_RozmiarPunktu, mz_RozmiarPunktu);
                //ustawienie atrybutów widoczności
                mz_Widoczny = true;
                mz_Pędzel.Dispose(); //zwolnienie pęzla
            }
            public virtual void mz_Wymaż(Control mz_Kontrolka, Graphics mz_PowierzchniaGraficzna)
            {
                if (this.mz_Widoczny)
                {
                    //wykreslenie punktu jako wypełnionego okręgu w mz_Kolorze tła
                    SolidBrush mz_Pędzel = new SolidBrush(mz_Kontrolka.BackColor);
                    mz_PowierzchniaGraficzna.FillEllipse(mz_Pędzel, mz_X - mz_RozmiarPunktu / 2,
                        mz_Y - mz_RozmiarPunktu / 2, mz_RozmiarPunktu, mz_RozmiarPunktu);
                    //ustawienie atrybutu widoczności
                    this.mz_Widoczny = false;
                    //zwolnienie pędzla
                    mz_Pędzel.Dispose();
                }
            }
        }//od klasy: Punkt

        //deklaracja klasy linii
        public class Linia : Punkt
        {
            /*klasa linia jest klasą pochodną klasy Punkt i będzie dziedziczyła 
             * jej atrybuty:
             * protected int X;
            protected int Y;
            protected Color mz_Kolor;
            protected DashStyle mz_RodzajLinii;
            protected int mz_Grubość;
            protected bool Widoczny;*/
            /*deklaracje prywatne (gdyż klasa Linia nie będzie klasa bazową
             * dla innej klasy) współrzędnych końca kreślonej linii prostej
             * (odcinka linii prostej)*/
            int mz_Xk, mz_Yk;
            // .  .  . deklaracje klasy Linia

            //deklaracja konstruktorów
            public Linia(int mz_Xp, int mz_Yp, int mz_Xk, int mz_Yk)
                : base(mz_Xp, mz_Yp)
            {
                this.mz_Xk = mz_Xk;
                this.mz_Yk = mz_Yk;
            }
            public Linia(int mz_Xp, int mz_Yp, int mz_Xk, int mz_Yk, Color mz_Kolor,
                DashStyle mz_RodzajLinii, int mz_GrubośćLinii)
                : base(mz_Xp, mz_Yp, mz_Kolor, mz_RodzajLinii, mz_GrubośćLinii)
            {
                this.mz_Xk = mz_Xk;
                this.mz_Yk = mz_Yk;
            }
            //nadpisanie metod wirtualnych, które są zadeklarowane w klasie Punkt
            public override void mz_Wykreśl(Graphics mz_PowierzchniaGraficzna)
            {//deklaracja pióra
                Pen mz_Pióro = new Pen(mz_Kolor, mz_Grubość);
                //ustalenie stylu linii dla Pióra
                mz_Pióro.DashStyle = this.mz_RodzajLinii;
                // mz_Wykreślenie linii
                mz_PowierzchniaGraficzna.DrawLine(mz_Pióro, this.mz_X, this.mz_Y, mz_Xk, mz_Yk);
                this.mz_Widoczny = true; //linia została mz_Wykreślona
                //zwolnienie zasobów graficznych
                mz_Pióro.Dispose();
            }
            public override void mz_Wymaż(Control mz_Kontrolka, Graphics mz_PowierzchniaGraficzna)
            {//deklaracja pióra
                Pen mz_Pióro = new Pen(mz_Kontrolka.BackColor, this.mz_Grubość);
                //mz_Wykreślenie linii (w mz_Kolorze tła, czyli wymazanie)
                mz_PowierzchniaGraficzna.DrawLine(mz_Pióro, this.mz_X, this.mz_Y, mz_Xk, mz_Yk);
                this.mz_Widoczny = false; //linia zastała wymazana
                //zwolnienie zasobów graficznych
                mz_Pióro.Dispose();
            }
        }//od klasy Linia

        public class Elipsa : Punkt
        {
            /*klasa linia jest klasą pochodną klasy Punkt i będzie dziedziczyła 
              jej atrybuty */
            
            protected int mz_OśDuża, mz_OśMała; // oś duża i oś mała Elipsy

            //deklaracja konstruktorów

            public Elipsa(int mz_x, int mz_y, int mz_OśDuża, int mz_OśMała)
                : base(mz_x, mz_y)
            {
                this.mz_OśDuża = mz_OśDuża;
                this.mz_OśMała = mz_OśMała;
            }

            public Elipsa(int mz_x, int mz_y, int mz_OśDuża, int mz_OśMała, Color mz_Kolor,
                DashStyle mz_RodzajLinii, int mz_GrubośćLinii)
                : base(mz_x, mz_y, mz_Kolor, mz_RodzajLinii, mz_GrubośćLinii)
            {
                this.mz_OśDuża = mz_OśDuża;
                this.mz_OśMała = mz_OśMała;
            }

            /* nadpisywanie metod wirtualnych, które były zadeklarowane w klasie bazowej 
             * (nadrzędnej): Punkt */
            public override void mz_Wykreśl(Graphics mz_PowierzchniaGraficzna)
            {
                /* deklaracje i utworzenie egzemplarza pióra (gdzie,zmienne:
                 * mz_Kolor, mz_GrubośćLinii zadeklarowane są w klasie bazowej Punkt) */
                Pen mz_Pióro = new Pen(mz_Kolor, mz_Grubość);
                /* formatowanie pióra (gdzie,zmienna:mz_RodzajLinii zadeklarowana 
                 * jest w klasie bazowej Punkt) */
               mz_Pióro.DashStyle = mz_RodzajLinii;
                //mz_Wykreślenie Elipsy
                mz_PowierzchniaGraficzna.DrawEllipse(mz_Pióro, mz_X - mz_OśDuża / 2, mz_Y - mz_OśMała / 2,
                    mz_OśDuża, mz_OśMała);
                mz_Widoczny = true;//elipsa została mz_Wykreślona
                //zwolnienie pióra
                mz_Pióro.Dispose();

            }
            public override void mz_Wymaż(Control mz_Kontrolka, Graphics mz_PowierzchniaGraficzna)
            {
                //ustawienie mz_Koloru pióra w mz_Kolorze tła planszy graficznej
                Pen mz_Pióro = new Pen(mz_Kontrolka.BackColor, this.mz_Grubość);
                mz_Pióro.DashStyle = this.mz_RodzajLinii;
                //wymazanie elipsy
                mz_PowierzchniaGraficzna.DrawEllipse(mz_Pióro, mz_X - mz_OśDuża / 2,
                    mz_Y - mz_OśMała / 2, mz_OśDuża, mz_OśMała);
                mz_Widoczny = false; //elipsa została wymazana
                //zwolnienie pióra
                mz_Pióro.Dispose();
            }
        }; // od klasy Elipsa

        public class Okrąg : Elipsa
        {
            /*klasa Okrąg jest klasą pochodną klasy Elipsa i dziedziczy od niej
              atrybuty */                        
            protected int mz_Promień;
            //deklaracja konstruktora klasy Okrąg
            public Okrąg(int mz_x, int mz_y, int mz_Promień)
                : base(mz_x, mz_y, 2 * mz_Promień, 2 * mz_Promień)
            {
                this.mz_Promień = mz_Promień;
            }
            public Okrąg(int mz_x, int mz_y, int mz_Promień, Color mz_Kolor, DashStyle mz_RodzajLinii,
                int mz_GrubośćLinii) : base(mz_x, mz_y, 2 * mz_Promień, 2 * mz_Promień, mz_Kolor,
                    mz_RodzajLinii, mz_GrubośćLinii)
            {
                this.mz_Promień = mz_Promień;
            }


            /*nadpisywanie metod wirtualnych, które były zadeklarowane w 
             * klasie bazowej Punkt:*/

            public override void mz_Wymaż(Control mz_Kontrolka, Graphics mz_PowierchniaGraficzna)
            {
                //deklaracja, utworzenie i formatowanie pióra (w mz_Kolorze tła planszy graficznej)
                Pen mz_Pióro = new Pen(mz_Kontrolka.BackColor, this.mz_Grubość);
                mz_Pióro.DashStyle = this.mz_RodzajLinii;
                //wymazanie okręgu
                mz_PowierchniaGraficzna.DrawEllipse(mz_Pióro, mz_X - mz_Promień, mz_Y - mz_Promień,
                    2 * mz_Promień, 2 * mz_Promień);
                mz_Widoczny = false;//okrąg został wymazany
                //zwolnienie Pióra
                mz_Pióro.Dispose();
            }
            public override void mz_Wykreśl(Graphics mz_PowierzchniaGraficzna)
            {
                Pen mz_Pióro = new Pen(mz_Kolor, mz_Grubość);
                mz_Pióro.DashStyle = mz_RodzajLinii;
                //wymazanie okręgu
                mz_PowierzchniaGraficzna.DrawEllipse(mz_Pióro, mz_X - mz_Promień, mz_Y - mz_Promień,
                    2 * mz_Promień, 2 * mz_Promień);
                mz_Widoczny = true;//okrąg został wymazany
                //zwolnienie Pióra
                mz_Pióro.Dispose();
            }
        };
        public class Prostokąt : Linia
        {
            // klasa Prostokąt jest pochodna klasy Linia
            protected int mz_Linia1, mz_Linia2;
            /// deklaracja konstruktora klasy Linia
            public Prostokąt(int mz_Xp, int mz_Yp, int mz_Linia1, int mz_Linia2)
                : base(mz_Xp, mz_Yp, 2 * mz_Linia1, 2 * mz_Linia2)
            {
                this.mz_Linia1 = mz_Linia1;
                this.mz_Linia2 = mz_Linia2;
            }

            public Prostokąt(int mz_x, int mz_y, int mz_Linia2, int mz_Linia1, Color mz_Kolor, DashStyle mz_RodzajLinii,
                int mz_GrubośćLinii) : base(mz_x, mz_y, 2 * mz_Linia1, 2 * mz_Linia2, mz_Kolor, mz_RodzajLinii, mz_GrubośćLinii)
            {
                this.mz_Linia1 = mz_Linia1;
                this.mz_Linia2 = mz_Linia2;
            }
            public override void mz_Wykreśl(Graphics mz_PowierzchniaGraficzna)
            {
                /* deklaracja i utworzenia egzemplarza pióra (gdzie, zmienne:
                 * mz_Kolor, mz_GrubośćLinii i zadeklarowane są w klasie bazowej Punkt) */
                Pen mz_Pióro = new Pen(mz_Kolor, mz_Grubość);
                // formatowanie pióra
                mz_Pióro.DashStyle = mz_RodzajLinii;
                // mz_Wykreślenie Prostokąt 
                mz_PowierzchniaGraficzna.DrawRectangle(mz_Pióro, this.mz_X, this.mz_Y, mz_Linia1, mz_Linia2);
                mz_Widoczny = true;  // prostokąt została wymazany 
                // zwolnienie pióra 
                mz_Pióro.Dispose();
            }
            // nadpisywanie metod wirtualnych, które były zadeklarowane w klasie bazowej Punkt
            public override void mz_Wymaż(Control mz_Kontrolka, Graphics mz_PowierzchniaGraficzna)
            {  // deklaracja, utworznia i formatowanie pióra 
                Pen mz_Pióro = new Pen(mz_Kontrolka.BackColor, this.mz_Grubość);
                mz_Pióro.DashStyle = this.mz_RodzajLinii;
                // wymazanie prostokokąta 
                mz_PowierzchniaGraficzna.DrawRectangle(mz_Pióro, this.mz_X, this.mz_Y, mz_Linia1, mz_Linia2);
                this.mz_Widoczny = false;
                mz_Pióro.Dispose();
            }
        };
        public class Kwadrat : Linia
        {    // klasa Kwadrat jest pochodna klasy Linia
            protected int mz_DługośćStrony;
            // deklaracja konstruktora klasy Linia 
            public Kwadrat(int mz_Xp, int mz_Yp, int mz_DługośćStrony)
                : base(mz_Xp, mz_Yp, 2 * mz_DługośćStrony, 2 * mz_DługośćStrony)
            {
                this.mz_DługośćStrony = mz_DługośćStrony;
            }
            public Kwadrat(int mz_x, int mz_y, int mz_DługośćStrony, Color mz_mz_Kolor, DashStyle mz_mz_RodzajLinii,
                int mz_mz_GrubośćLinii) : base(mz_x, mz_y, 2 * mz_DługośćStrony, 2 * mz_DługośćStrony, mz_mz_Kolor, mz_mz_RodzajLinii, mz_mz_GrubośćLinii)
            {
                this.mz_DługośćStrony = mz_DługośćStrony;
            }
            public override void mz_Wykreśl(Graphics mz_PowierzchniaGraficzna)
            {
                /* deklaracja i utworzenia egzemplarza pióra (gdzie, zmienne:
                 * mz_Kolor, mz_GrubośćLinii i zadeklarowane są w klasie bazowej Punkt) */
                Pen mz_Pióro = new Pen(mz_Kolor, mz_Grubość);
                /* formatowanie pióra (gdzie, zmienna: mz_RodzajLinii zadeklaroana jest w klasie bazowej Punkt) */
                mz_Pióro.DashStyle = mz_RodzajLinii;
                // mz_Wykreślenie Kwadrat 
                mz_PowierzchniaGraficzna.DrawRectangle(mz_Pióro, this.mz_X, this.mz_Y, mz_DługośćStrony, mz_DługośćStrony);
                mz_Widoczny = true; // kwadrat zostal mz_Wykreślony
                // zwolnienie pióra 
                mz_Pióro.Dispose();
            }
            public override void mz_Wymaż(Control mz_Kontrolka, Graphics mz_PowierzchniaGraficzna)
            { // deklaracja, utworznia i formatowanie pióra 
                Pen mz_Pióro = new Pen(mz_Kontrolka.BackColor, this.mz_Grubość);
                mz_Pióro.DashStyle = this.mz_RodzajLinii;
                // wymazanie kwadrata
                mz_PowierzchniaGraficzna.DrawRectangle(mz_Pióro, this.mz_X, this.mz_Y, mz_DługośćStrony, mz_DługośćStrony);
                this.mz_Widoczny = false;
                // zwolnienie Pióra 
                mz_Pióro.Dispose();
            }
        };
        public class Trójkąt : Punkt
        { // klasa Trójkąt jest pochodna klasy Punkt
            protected PointF mz_DługośćStrony1;
            protected PointF mz_DługośćStrony2;
            protected PointF mz_DługośćStrony3;

            // deklaracja konstruktora klasy Trójkąt 
            public Trójkąt(int mz_Xp, int mz_Yp, PointF mz_DługośćStrony1, PointF mz_DługośćStrony2, PointF mz_DługośćStrony3)
                : base(mz_Xp, mz_Yp)
            {
                this.mz_DługośćStrony1 = mz_DługośćStrony1;
                this.mz_DługośćStrony2 = mz_DługośćStrony2;
                this.mz_DługośćStrony3 = mz_DługośćStrony3;
            }
            public Trójkąt(int mz_Xp, int mz_Yp, PointF mz_DługośćStrony1, PointF mz_DługośćStrony2, PointF mz_DługośćStrony3, Color mz_Kolor,
               DashStyle mz_RodzajLinii, int mz_GrubośćLinii)
                    : base(mz_Xp, mz_Yp, mz_Kolor, mz_RodzajLinii, mz_GrubośćLinii)
            {
                this.mz_DługośćStrony1 = mz_DługośćStrony1;
                this.mz_DługośćStrony2 = mz_DługośćStrony2;
                this.mz_DługośćStrony3 = mz_DługośćStrony3;
            }
            public override void mz_Wymaż(Control mz_Kontrolka, Graphics mz_PowierzchniaGraficzna)
            { // ustawienie mz_Koloru pióra
                Pen mz_Pióro = new Pen(mz_Kontrolka.BackColor, this.mz_Grubość);
                mz_Pióro.DashStyle = this.mz_RodzajLinii;
                // wymazanie Trójkąt
                PointF[] mz_IlośćStron =
                          {
                                 mz_DługośćStrony1,
                                 mz_DługośćStrony2,
                                 mz_DługośćStrony3
                             };

                mz_PowierzchniaGraficzna.DrawPolygon(mz_Pióro, mz_IlośćStron);
                this.mz_Widoczny = false;
                mz_Pióro.Dispose();
            }
            public override void mz_Wykreśl(Graphics mz_PowierzchniaGraficzna)
            {
                /* deklaracja i utworzenia egzemplarza pióra (gdzie, zmienne:
                 * mz_Kolor, mz_GrubośćLinii i zadeklarowane są w klasie bazowej Punkt) */
                Pen mz_Pióro = new Pen(mz_Kolor, mz_Grubość);
                /* formatowanie pióra (gdzie, zmienna: mz_RodzajLinii zadeklaroana jest w klasie bazowej Punkt) */
                mz_Pióro.DashStyle = mz_RodzajLinii;
                // mz_Wykreślenie Trójkąt 
                PointF[] mz_IlośćStron =
                          {
                                 mz_DługośćStrony1,
                                 mz_DługośćStrony2,
                                 mz_DługośćStrony3
                             };


                mz_PowierzchniaGraficzna.DrawPolygon(mz_Pióro, mz_IlośćStron);
                mz_Widoczny = true;
                // Trójkąt został wymazany 
                // zwolnienie Pióra 
                mz_Pióro.Dispose();
            }
        };
        public class KołoJednobarwne : Okrąg
        {
            // klasa KołoJednobarwne jest pochodna klasy Okrąg
            // deklaracja konstruktora klasy KołoJednobarwne 
            public KołoJednobarwne(int mz_x, int mz_y, int mz_Promień)
                : base(mz_x, mz_y, 2 * mz_Promień)
            {
                this.mz_Promień = mz_Promień;
            }
            public KołoJednobarwne(int mz_x, int mz_y, int mz_Promień, Color mz_Kolor, DashStyle mz_RodzajLinii,
                int mz_GrubośćLinii) : base(mz_x, mz_y, 2 * mz_Promień)
            {
                this.mz_Promień = mz_Promień;
            }
            // nadpisywanie metod wirtualnych, które były zadeklarowane w klasie bazowej Punkt
            public override void mz_Wymaż(Control mz_Kontrolka, Graphics mz_PowierzchniaGraficzna)
            {
                // deklaracja, utworznia i formatowanie pióra 
                SolidBrush mz_Pióro =  new SolidBrush (mz_Kolor);

                // wymazanie KołoJednobarwne 
                mz_PowierzchniaGraficzna.FillEllipse(mz_Pióro, this.mz_X - mz_Promień, this.mz_Y - mz_Promień,
                        mz_Promień, mz_Promień);
                mz_Widoczny = false;
                // zwolnienie Pióra 
                mz_Pióro.Dispose();
            }
            public override void mz_Wykreśl(Graphics mz_PowierzchniaGraficzna)
            {
                // deklaracja, utworznia i formatowanie pióra 
                SolidBrush mz_Pióro = new SolidBrush(mz_Kolor);
                // wymazanie KołoJednobarwne 
                mz_PowierzchniaGraficzna.FillEllipse(mz_Pióro, this.mz_X - mz_Promień, this.mz_Y - mz_Promień,
                       mz_Promień, mz_Promień);
                mz_Widoczny = true; // KołoJednobarwne została wymazany 
                                    // zwolnienie Pióra 
                mz_Pióro.Dispose();
            }
        }
        public class ProstokątJednobarwny : Prostokąt
        { // klasa ProstokątJednobarwny jest pochodna klasy Prostokąt
            protected int mz_Linia_1, mz_Linia_2;
            // deklaracja konstruktora 
            public ProstokątJednobarwny(int mz_Xp, int mz_Yp, int mz_Linia_1, int mz_Linia_2)
                : base(mz_Xp, mz_Yp, 2 * mz_Linia_1, 2 * mz_Linia_2)
            {
                this.mz_Linia_1 = mz_Linia_1;
                this.mz_Linia_2 = mz_Linia_2;
            }
            public ProstokątJednobarwny(int mz_x, int mz_y, int mz_Linia_1, int mz_Linia_2, Color mz_Kolor, DashStyle mz_RodzajLinii,
                int mz_GrubośćLinii) : base(mz_x, mz_y, 2 * mz_Linia_1, 2 * mz_Linia_2, mz_Kolor, mz_RodzajLinii, mz_GrubośćLinii)
            {
                this.mz_Linia_1 = mz_Linia_1;
                this.mz_Linia_2 = mz_Linia_2;
            }
            public override void mz_Wymaż(Control mz_Kontrolka, Graphics mz_PowierzchniaGraficzna)
            { // ustawienie mz_Koloru pióra
                Color mz_red = mz_Kontrolka.BackColor;
                Brush mz_Pióro = new SolidBrush(mz_red);
                // wymazanie ProstokątJednobarwny
                mz_PowierzchniaGraficzna.FillRectangle(mz_Pióro, this.mz_X, this.mz_Y, mz_Linia_1, mz_Linia_2);
                this.mz_Widoczny = false;
                // zwolnienie pióra
                mz_Pióro.Dispose();
            }
            public override void mz_Wykreśl(Graphics mz_PowierzchniaGraficzna)
            {
                /* deklaracja i utworzenia egzemplarza pióra (gdzie, zmienne:
                 * mz_Kolor, mz_GrubośćLinii i zadeklarowane są w klasie bazowej Punkt) */
                Color mz_blue = mz_Kolor;
                Brush mz_Pióro = new SolidBrush(mz_blue);
                // mz_Wykreślenie ProstokątJednobarwny 
                mz_PowierzchniaGraficzna.FillRectangle(mz_Pióro, this.mz_X, this.mz_Y, mz_Linia_1, mz_Linia_2);
                mz_Widoczny = true; // ProstokątJednobarwny został mz_Wykreślony 
                // zwolnienie pióra 
                mz_Pióro.Dispose();
            }
        }
        public class KwadratJednobarwny : Linia
        {
            protected int mz_DługośćStrony_1;
            // deklaracja konstruktora klasy Okrąg 
            public    KwadratJednobarwny(int mz_Xp, int mz_Yp, int mz_DługośćStrony)
                : base(   mz_Xp,    mz_Yp, 2 *    mz_DługośćStrony, 2 *    mz_DługośćStrony)
            {
                this.mz_DługośćStrony_1 = mz_DługośćStrony;
            }
            public KwadratJednobarwny(int mz_x, int mz_y, int mz_DługośćStrony, Color mz_Kolor, DashStyle mz_RodzajLinii,
                int mz_GrubośćLinii) : base(mz_x, mz_y, 2 * mz_DługośćStrony, 2 * mz_DługośćStrony, mz_Kolor, mz_RodzajLinii, mz_GrubośćLinii)
            {
                this.mz_DługośćStrony_1 = mz_DługośćStrony;
            }
            public override void mz_Wykreśl(Graphics mz_PowierzchniaGraficzna)
            {
                /* deklaracja i utworzenia egzemplarza pióra (gdzie, zmienne:
                 * mz_Kolor, mz_GrubośćLinii i zadeklarowane są w klasie bazowej Punkt) */
                Color mz_Red = mz_Kolor;
                Brush mz_Pióro = new SolidBrush(mz_Red);
                // mz_Wykreślenie kwadrata 
                mz_PowierzchniaGraficzna.FillRectangle(mz_Pióro, this.mz_X, this.mz_Y, mz_DługośćStrony_1, mz_DługośćStrony_1);
                mz_Widoczny = true;  // kwadrat zostal mz_Wykreślony
                // zwolnienie pióra 
                mz_Pióro.Dispose();
            }
            public override void mz_Wymaż(Control mz_Kontrolka, Graphics mz_PowierzchniaGraficzna)
            { // ustawienie mz_Koloru pióra w mz_Kolorze tła planszy graficznej 
                Color mz_Red = mz_Kontrolka.BackColor;
                Brush mz_Pióro = new SolidBrush(mz_Red);
                mz_PowierzchniaGraficzna.FillRectangle(mz_Pióro, this.mz_X, this.mz_Y, mz_DługośćStrony_1, mz_DługośćStrony_1);
                this.mz_Widoczny = false;
                // zwolnienie pióra 
                mz_Pióro.Dispose();
            }
        }
        private void trbSuwakGrubośćLinii_Scroll(object sender, EventArgs e)
        {
            // ustawienie grubości linii w kontrolce Textbox 
            // o identyfikatorze txtmz_GrubośćLinii
            txtGrubośćLinii.Text = trbSuwakGrubośćLinii.Value.ToString();
            nudGrubość.Text = trbSuwakGrubośćLinii.Value.ToString();
           
        }
        private void nudGrubość_ValueChanged(object sender, EventArgs e)
        {
            txtGrubośćLinii.Text = nudGrubość.Value.ToString();
            trbSuwakGrubośćLinii.Value = (int)nudGrubość.Value;
        }
       

        private void imgRysownica_MouseDown(object sender, MouseEventArgs e)
        {// monitoring położenia myszy
            lblWspX.Text = e.Location.X.ToString();
            lblWspY.Text = e.Location.Y.ToString();
            if (e.Button == MouseButtons.Left)
                // zapamiętanie współrzędnych położemia myszy
                mz_PunktStartu = e.Location;

        }

        private void imgRysownica_MouseUp(object sender, MouseEventArgs e)
        {// monitoring położenia myszy
            lblWspX.Text = e.Location.X.ToString();
            lblWspY.Text = e.Location.Y.ToString();
            // sprawdzenie, czy zwolnienie przycisku dotyczy przycisku lewego
            if (e.Button == MouseButtons.Left)
            {
                // deklaracja pióra
                Pen mz_Pióro = new Pen(txtKolorLinii.BackColor,
                                    trbSuwakGrubośćLinii.Value);
                mz_Pióro.DashStyle = mz_WybranyStylLinii(cmbStylLinii.SelectedIndex);
                Brush mz_Pędzel_1 = new SolidBrush(txtKolorLinii.BackColor);
                if (rdbPunkt.Checked)
                {
                    SolidBrush Pędzel = new SolidBrush(txtKolorLinii.BackColor);
                    mz_Rysownica.FillEllipse(Pędzel, mz_PunktStartu.X - 5,
                                                     mz_PunktStartu.Y - 5,
                                                  10, 10);
                    imgRysownica.Refresh();
                    //Utworzenie egzemplarza punktu
                    mz_LFG.Add(new Punkt(mz_PunktStartu.X, mz_PunktStartu.Y));
                    //Ustawienie atrybutów graficznych figury geometrycznej
                    //(mz_Kolor,rodzaj linii,mz_Grubość linii)
                    mz_LFG[mz_LFG.Count - 1].mz_FormatujFG(txtKolorLinii.BackColor,
                        mz_WybranyStylLinii(cmbStylLinii.SelectedIndex), trbSuwakGrubośćLinii.Value, nudGrubość.Value);
                }
                if (rdbLiniaProsta.Checked)
                {
                    // mz_Wykreślenie linii
                    mz_Rysownica.DrawLine(mz_Pióro, mz_PunktStartu.X, mz_PunktStartu.Y,
                                       e.Location.X, e.Location.Y);
                    imgRysownica.Refresh();
                    //utworzenie egzemplarza opisu linii w strukturze danych:

                    mz_LFG.Add(new Linia(mz_PunktStartu.X, mz_PunktStartu.Y, e.Location.X, e.Location.Y));
                    //ustawienie atrybutów graficznych figury geometrycznej
                    //(mz_Kolor, rodzaj linii, mz_Grubość linii)
                    mz_LFG[mz_LFG.Count - 1].mz_FormatujFG(txtKolorLinii.BackColor,
                        mz_WybranyStylLinii(cmbStylLinii.SelectedIndex), trbSuwakGrubośćLinii.Value, nudGrubość.Value);
                }
                if (rdbElipsa.Checked)
                {
                    //mz_Wykreślenie elipsy
                    int mz_Szerokośc = Math.Abs(mz_PunktStartu.X - e.Location.X);
                    int mz_Wysokość = Math.Abs(mz_PunktStartu.Y - e.Location.Y);
                    mz_Rysownica.DrawEllipse(mz_Pióro, mz_PunktStartu.X, mz_PunktStartu.Y,
                                                   mz_Szerokośc, mz_Wysokość);
                    imgRysownica.Refresh();
                    //Utworzenie egzemplarza opisu elipsy w strukturze danych:
                    mz_LFG.Add(new Elipsa(mz_PunktStartu.X, mz_PunktStartu.Y, mz_Szerokośc, mz_Wysokość));
                    //Ustawienie atrybutów graficznych figury geometrycznej
                    //(mz_Kolor,rodzaj linii, mz_Grubość linii)
                    mz_LFG[mz_LFG.Count - 1].mz_FormatujFG(txtKolorLinii.BackColor,
                       mz_WybranyStylLinii(cmbStylLinii.SelectedIndex), trbSuwakGrubośćLinii.Value, nudGrubość.Value);
                }
                if (rdbOkrąg.Checked)
                {        // mz_Wykreślenie okrągu

                    int mz_Promień = Math.Abs(mz_PunktStartu.X - e.Location.X);
                    mz_Rysownica.DrawEllipse(mz_Pióro, mz_PunktStartu.X, mz_PunktStartu.Y, mz_Promień, mz_Promień);
                    imgRysownica.Refresh();
                    //utworzenie egzemplarza opisu okrągu w strukturze danych:
                    mz_LFG.Add(new Okrąg(mz_PunktStartu.X, mz_PunktStartu.Y, mz_Promień));
                    //ustawienie atrybutów graficznych figury geometrycznej
                    //(mz_Kolor, rodzaj linii, mz_Grubość linii)
                    mz_LFG[mz_LFG.Count - 1].mz_FormatujFG(txtKolorLinii.BackColor,
                        mz_WybranyStylLinii(cmbStylLinii.SelectedIndex), trbSuwakGrubośćLinii.Value, nudGrubość.Value);
                }
                if (rdbProstokąt.Checked)
                {
                    // mz_Wykreślenie prostokąta 
                    int mz_Linia1 = Math.Abs(mz_PunktStartu.X - e.Location.X);
                    int mz_Linia2 = Math.Abs(mz_PunktStartu.Y - e.Location.Y);
                    mz_Rysownica.DrawRectangle(mz_Pióro, mz_PunktStartu.X, mz_PunktStartu.Y, mz_Linia1, mz_Linia2);
                    imgRysownica.Refresh();
                    //utworzenie egzemplarza opisu prostokąta  w strukturze danych
                    mz_LFG.Add(new Prostokąt(mz_PunktStartu.X, mz_PunktStartu.Y, mz_Linia1, mz_Linia2));
                    //ustawienie atrybutów graficznych figury geometrycznej
                    //(mz_Kolor, rodzaj linii, mz_Grubość linii)
                    mz_LFG[mz_LFG.Count - 1].mz_FormatujFG(txtKolorLinii.BackColor,
                        mz_WybranyStylLinii(cmbStylLinii.SelectedIndex), trbSuwakGrubośćLinii.Value, nudGrubość.Value);
                }
                if (rdbKwadrat.Checked)
                {
                    // mz_Wykreślenie kwadrata
                    int DługośćStrony = Math.Abs(mz_PunktStartu.X - e.Location.X);

                    mz_Rysownica.DrawRectangle(mz_Pióro, mz_PunktStartu.X, mz_PunktStartu.Y, DługośćStrony, DługośćStrony);
                    imgRysownica.Refresh();
                    //utworzenie egzemplarza opisu kwadrata w strukturze danych
                    mz_LFG.Add(new Kwadrat(mz_PunktStartu.X, mz_PunktStartu.Y, DługośćStrony));
                    //ustawienie atrybutów graficznych figury geometrycznej
                    //(mz_Kolor, rodzaj linii, mz_Grubość linii)
                    mz_LFG[mz_LFG.Count - 1].mz_FormatujFG(txtKolorLinii.BackColor,
                        mz_WybranyStylLinii(cmbStylLinii.SelectedIndex), trbSuwakGrubośćLinii.Value, nudGrubość.Value);
                }
                
              if (rdbKołoJednobarwne.Checked)
                {
                    int mz_Promień = Math.Abs(mz_PunktStartu.X - e.Location.X);
                    mz_Rysownica.FillEllipse(mz_Pędzel_1, mz_PunktStartu.X, mz_PunktStartu.Y, mz_Promień, mz_Promień);
                    imgRysownica.Refresh();
                    //utworzenie egzemplarza opisu okrągu w strukturze danych:
                    mz_LFG.Add(new Okrąg(mz_PunktStartu.X, mz_PunktStartu.Y, mz_Promień));
                    //ustawienie atrybutów graficznych figury geometrycznej
                    //(mz_Kolor, rodzaj linii, mz_Grubość linii)
                    mz_LFG[mz_LFG.Count - 1].mz_FormatujFG(txtKolorLinii.BackColor,
                        mz_WybranyStylLinii(cmbStylLinii.SelectedIndex), trbSuwakGrubośćLinii.Value , nudGrubość.Value);
                }
                if (rdbProstokątJednobarwny.Checked)
                {
                    // mz_Wykreślenie prostokąta 
                    int mz_Linia1 = Math.Abs(mz_PunktStartu.X - e.Location.X);
                    int mz_Linia2 = Math.Abs(mz_PunktStartu.Y - e.Location.Y);
                    mz_Rysownica.FillRectangle(mz_Pędzel_1, mz_PunktStartu.X, mz_PunktStartu.Y, mz_Linia1, mz_Linia2);
                    imgRysownica.Refresh();
                    //utworzenie egzemplarza opisu prostokąta  w strukturze danych
                    mz_LFG.Add(new Prostokąt(mz_PunktStartu.X, mz_PunktStartu.Y, mz_Linia1, mz_Linia2));
                    //ustawienie atrybutów graficznych figury geometrycznej
                    //(mz_Kolor, rodzaj linii, mz_Grubość linii)
                    mz_LFG[mz_LFG.Count - 1].mz_FormatujFG(txtKolorLinii.BackColor,
                        mz_WybranyStylLinii(cmbStylLinii.SelectedIndex), trbSuwakGrubośćLinii.Value, nudGrubość.Value);
                }
                if (rdbKwadratJednobarwny.Checked)
                {
                    // mz_Wykreślenie kwadrata
                    int mz_DługośćStrony = Math.Abs(mz_PunktStartu.X - e.Location.X);

                    mz_Rysownica.FillRectangle(mz_Pędzel_1, mz_PunktStartu.X, mz_PunktStartu.Y, mz_DługośćStrony, mz_DługośćStrony);
                    imgRysownica.Refresh();
                    //utworzenie egzemplarza opisu kwadrata w strukturze danych
                    mz_LFG.Add(new Kwadrat(mz_PunktStartu.X, mz_PunktStartu.Y, mz_DługośćStrony));
                    //ustawienie atrybutów graficznych figury geometrycznej
                    //(mz_Kolor, rodzaj linii, mz_Grubość linii)
                    mz_LFG[mz_LFG.Count - 1].mz_FormatujFG(txtKolorLinii.BackColor,
                        mz_WybranyStylLinii(cmbStylLinii.SelectedIndex), trbSuwakGrubośćLinii.Value, nudGrubość.Value);
                }
            }
        }
        

        private void imgRysownica_MouseMove(object sender, MouseEventArgs e)
        {// monitoring położenia myszy
            lblWspX.Text = e.Location.X.ToString();
            lblWspY.Text = e.Location.Y.ToString();
            // utworzenie przezroczysterj powierzchni graficzneh na kontrolce PictureBox
            Graphics mz_RysownicaPrzezroczysta = imgRysownica.CreateGraphics();
            // utworzenie pióra dla kreślenie linii na przezroczystej powierzchni graficznej
            Pen mz_Pióro = new Pen(txtKolorLinii.BackColor,
                                    trbSuwakGrubośćLinii.Value);
            mz_Pióro.DashStyle = DashStyle.Solid;
            Brush mz_Pędzel_1 = new SolidBrush(txtKolorLinii.BackColor);
            // wyznaczenie rozmiarów obszaru, w który będzie wrysowana figura geometryczna
            int mz_Szerokośc = Math.Abs(mz_PunktStartu.X - e.Location.X);
            int mz_Wysokość = Math.Abs(mz_PunktStartu.Y - e.Location.Y);
            int mz_Promień = Math.Abs(mz_PunktStartu.X - e.Location.X);
            int mz_Linia1 = Math.Abs(mz_PunktStartu.X - e.Location.X);
            int mz_Linia2 = Math.Abs(mz_PunktStartu.Y - e.Location.Y);
            int mz_DługośćStrony = Math.Abs(mz_PunktStartu.X - e.Location.X);
            PointF mz_DługośćStrony1 = new PointF(mz_rand.Next(20, 400), mz_rand.Next(20, 400));
            PointF mz_DługośćStrony2 = new PointF(mz_rand.Next(20, 400), mz_rand.Next(20, 400));
            PointF mz_DługośćStrony3 = new PointF(mz_rand.Next(20, 400), mz_rand.Next(20, 400));
            PointF[] mz_IlośćStron =
                        {
                                    mz_DługośćStrony1,
                                    mz_DługośćStrony2,
                                   mz_DługośćStrony3
                             };


            // sprawdzenie, czy został zwolniony lewy przycisk myszy
            if (e.Button == MouseButtons.Left)
            {
                // pomijamy rozciąganie punktu, ale można!
                if (rdbLiniaProsta.Checked)
                {
                    mz_RysownicaPrzezroczysta.DrawLine(mz_Pióro, mz_PunktStartu.X,
                             mz_PunktStartu.Y, e.Location.X, e.Location.Y);
                    imgRysownica.Refresh();

                }
                else if (rdbLiniaProsta.Checked)
                {
                    mz_RysownicaPrzezroczysta.DrawLine(mz_Pióro, mz_PunktStartu, e.Location);
                    imgRysownica.Refresh();
                }
                else if (rdbElipsa.Checked)
                {
                    mz_RysownicaPrzezroczysta.DrawEllipse(mz_Pióro, mz_PunktStartu.X,
                           mz_PunktStartu.Y, mz_Szerokośc, mz_Wysokość);
                    imgRysownica.Refresh();

                }
                else if (rdbOkrąg.Checked)
                {
                    mz_RysownicaPrzezroczysta.DrawEllipse(mz_Pióro, mz_PunktStartu.X,
                          mz_PunktStartu.Y, mz_Szerokośc, mz_Szerokośc);
                    imgRysownica.Refresh();
                }
                else if (rdbProstokąt.Checked)
                {
                    mz_RysownicaPrzezroczysta.DrawRectangle(mz_Pióro, mz_PunktStartu.X, mz_PunktStartu.Y, mz_Linia1, mz_Linia2);
                    imgRysownica.Refresh();
                }
                else if (rdbKwadrat.Checked)
                {
                    mz_RysownicaPrzezroczysta.DrawRectangle(mz_Pióro, mz_PunktStartu.X, mz_PunktStartu.Y, mz_DługośćStrony, mz_DługośćStrony);
                    imgRysownica.Refresh();
                }
                
                else if (rdbKołoJednobarwne.Checked)
                {
                    mz_RysownicaPrzezroczysta.FillEllipse(mz_Pędzel_1, mz_PunktStartu.X,
                         mz_PunktStartu.Y, mz_Szerokośc, mz_Szerokośc);
                    imgRysownica.Refresh();
                }
                else if (rdbProstokątJednobarwny.Checked)
                {
                    mz_RysownicaPrzezroczysta.FillRectangle(mz_Pędzel_1, mz_PunktStartu.X, mz_PunktStartu.Y, mz_Linia1, mz_Linia2);
                    imgRysownica.Refresh();
                }
                else if (rdbKwadratJednobarwny.Checked)
                {
                    mz_RysownicaPrzezroczysta.FillRectangle(mz_Pędzel_1, mz_PunktStartu.X, mz_PunktStartu.Y, mz_DługośćStrony, mz_DługośćStrony);
                    imgRysownica.Refresh();
                }
               
                else if (rdbGumka.Checked)
                {
                    mz_Pióro.Color = imgRysownica.BackColor;
                    GraphicsPath mz_Path = new GraphicsPath();
                    do
                    {
                        PointF mz_Point1 = new PointF(e.Location.X, e.Location.Y);
                        SizeF mz_Grubość = new SizeF(trbSuwakGrubośćLinii.Value, 10);
                        RectangleF rect = new RectangleF(mz_Point1, mz_Grubość);
                        mz_Path.AddEllipse(rect);

                    } while (e.Button != MouseButtons.Left);
                    mz_Rysownica.DrawPath(mz_Pióro, mz_Path);

                    imgRysownica.Refresh();
                }
            }
           
        }
        private DashStyle mz_WybranyStylLinii(int mz_i)
        {
            switch (mz_i)
            {
                case 0:
                    return DashStyle.Dash;
                case 1:
                    return DashStyle.DashDot;
                case 2:
                    return DashStyle.DashDotDot;
                case 3:
                    return DashStyle.Dot;
                case 4:
                    return DashStyle.Solid;
                default:
                    MessageBox.Show("ERROR: Nie ma takiego rodzaju linii!");
                    return DashStyle.Solid;
            } // od switch
        }
         private void btnZmianaKolLinii_Click(object sender, EventArgs e)
        {
            //deklaracja i utworzenie okna wyboru mz_Koloru
            ColorDialog mz_Oknomz_Kolorów = new ColorDialog();
            //zaznacz w palecie aktualny mz_Kolor linii
            mz_Oknomz_Kolorów.Color = txtKolorLinii.BackColor;
            if (mz_Oknomz_Kolorów.ShowDialog() == DialogResult.OK)
            {
                //"zapamiętanie" wybranego mz_Koloru w kontrolce txtmz_KolorLinii
                txtKolorLinii.BackColor = mz_Oknomz_Kolorów.Color;
                
            }
        }
   

        private void btnZmianaKolRysownicy_Click(object sender, EventArgs e)
        {
            //deklaracja i utworzenie okna wyboru mz_Koloru
            ColorDialog mz_OknoKolorów = new ColorDialog();
            //zaznacz w palecie mz_Kolorów aktualny mz_Kolor tła
            mz_OknoKolorów.Color = txtKolorTła.BackColor;
            if (mz_OknoKolorów.ShowDialog() == DialogResult.OK)
            {
                imgRysownica.BackColor = mz_OknoKolorów.Color;
                txtKolorTła.BackColor = mz_OknoKolorów.Color;

            }
        }


        private void btnPrzesuńFigury_Click(object sender, EventArgs e)
        {
            //"wyczyszczenie" powierzchni rysownicy
            mz_Rysownica.Clear(txtKolorTła.BackColor);
            imgRysownica.Refresh(); //odświeżenie powierzchni Kontrolki PictureBox

            //określenie rozmiarów powierzchni do rysowania
            int mz_Xmax = imgRysownica.Width;
            int mz_Ymax = imgRysownica.Height;
            //deklaracja i utworzenie egzemplarza obiektu Random
            Random mz_LiczbaLosowa = new Random();
            //pomocnicze deklaracje lokalne
            int mz_NoweXp, mz_NoweYp;

            for (int mz_i = 0; mz_i < mz_LFG.Count; mz_i++)
            {
                //wylosowanie współrzędnych położenia dla figury geometrycznej 
                //z i-tej pozycji listy LFG
                mz_NoweXp = mz_LiczbaLosowa.Next(mz_Margines, mz_Xmax / 2);
                mz_NoweYp = mz_LiczbaLosowa.Next(mz_Margines, mz_Ymax / 2);
                //ustawienie nowego położenia figury geometrycznej 
                //zapisanej w i-tej pozycji LFG
                mz_LFG[mz_i].mz_PrzesuńDoNowegoXY(imgRysownica, mz_Rysownica, mz_NoweXp, mz_NoweYp); //Dzięki mechanizmowi
                //poliformizmu, metoda PrzesunDoNowegoXY "potrafi" przesunąć punkt,
                //okrąg i dowolne inne figury geometryczne
            } //for
            imgRysownica.Refresh(); //odświeżenie powierzchni Kontrolki PictureBox
        }

        private void btnLosowaZmianaAtrybutów_Click(object sender, EventArgs e)
        {
            //"wyczyszczenie" powierzchni rysowanicy
            mz_Rysownica.Clear(txtKolorTła.BackColor);
            imgRysownica.Refresh(); //odświeżenie powierzchni kontrolki PictureBox
            //deklaracje pomocnicze i utworzenie egzemplarza obiektu Random
            Random mz_LiczbaLosowa = new Random();
            int mz_GrubośćLinii;
            int  mz_GrubośćLinii2;
            DashStyle mz_StylLinii;
            Color mz_Kolor;
            for (int mz_i = 0; mz_i < mz_LFG.Count; mz_i++)
            {
                //wylosowanie mz_Koloru dla figury geometrycznej
                mz_Kolor = Color.FromArgb(mz_LiczbaLosowa.Next(0, 255),
                                           mz_LiczbaLosowa.Next(0, 255),
                                           mz_LiczbaLosowa.Next(0, 255));
                //wylosowanie rodzaju linii
                switch (mz_LiczbaLosowa.Next(1, 6))
                {
                    case 1:
                        mz_StylLinii = DashStyle.Dash;
                        break;
                    case 2:
                        mz_StylLinii = DashStyle.DashDot;
                        break;
                    case 3:
                        mz_StylLinii = DashStyle.DashDotDot;
                        break;
                    case 4:
                        mz_StylLinii = DashStyle.Dot;
                        break;
                    case 5:
                        mz_StylLinii = DashStyle.Solid;
                        break;
                    default:
                        mz_StylLinii = DashStyle.Solid;
                        break;
                }
                //wylosowanie grubości linii
                mz_GrubośćLinii = mz_LiczbaLosowa.Next(1, 10);
                mz_GrubośćLinii2 = mz_LiczbaLosowa.Next(1, 10);
                //ustawienie atrybutów graficznych figury geometrycznej 
                // (mz_Kolor, rodzaj linii, mz_Grubość linii)
                mz_LFG[mz_i].mz_FormatujFG(mz_Kolor, mz_StylLinii, mz_GrubośćLinii, mz_GrubośćLinii2);
                //mz_Wykreślenie figury geometrycznej 
                //zapisanej w i-tej pozycji listy LFG
                mz_LFG[mz_i].mz_Wykreśl(mz_Rysownica);
                /*dzięki mechanizmowi polimorfizmu, metoda mz_Wykreśl (...)
                  "potrafi" mz_Wykreślić figurę geometryczną , której klasą 
                  nadrzędną jest klasa Punkt*/
            } //for
            imgRysownica.Refresh(); //odświeżenie powierzchni kontrolki PictureBox
        }

        private void przesuneńDoNowegoXYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //"wyczyszczenie" powierzchni rysownicy
            mz_Rysownica.Clear(txtKolorTła.BackColor);
            imgRysownica.Refresh(); //odświeżenie powierzchni Kontrolki PictureBox

            //określenie rozmiarów powierzchni do rysowania
            int mz_Xmax = imgRysownica.Width;
            int mz_Ymax = imgRysownica.Height;
            //deklaracja i utworzenie egzemplarza obiektu Random
            Random mz_LiczbaLosowa = new Random();
            //pomocnicze deklaracje lokalne
            int mz_NoweXp, mz_NoweYp;

            for (int mz_i = 0; mz_i < mz_LFG.Count; mz_i++)
            {
                //wylosowanie współrzędnych położenia dla figury geometrycznej 
                //z i-tej pozycji listy LFG
                mz_NoweXp = mz_LiczbaLosowa.Next(mz_Margines, mz_Xmax / 2);
                mz_NoweYp = mz_LiczbaLosowa.Next(mz_Margines, mz_Ymax / 2);
                //ustawienie nowego położenia figury geometrycznej 
                //zapisanej w i-tej pozycji LFG
                mz_LFG[mz_i].mz_PrzesuńDoNowegoXY(imgRysownica, mz_Rysownica, mz_NoweXp, mz_NoweYp); //Dzięki mechanizmowi
                //poliformizmu, metoda PrzesunDoNowegoXY "potrafi" przesunąć punkt,
                //okrąg i dowolne inne figury geometryczne
            } //for
            imgRysownica.Refresh(); //odświeżenie powierzchni Kontrolki PictureBox
            }

        private void btnNastępny_Click(object sender, EventArgs e)
        {
            int mz_NrSlaidu;
            if (!int.TryParse(txtNrSlajdu.Text, out mz_NrSlaidu))
            {
                errorProvider1.SetError(txtNrSlajdu, "ERROR: Bікdny zapis nr slaidu");
                return;
            }
            if ((mz_NrSlaidu < 0) || (mz_NrSlaidu >= mz_LFG.Count))
            {
                errorProvider1.SetError(txtNrSlajdu, "Error : nie ma takiego nr slaidu");
                return;
            }
            errorProvider1.Dispose();



            mz_Rysownica.Clear(txtKolorTła.BackColor);
            imgRysownica.Refresh(); // powierzchni kontrolki PictureBox


            if (mz_NrSlaidu < (mz_LFG.Count - 1))
            {
                mz_NrSlaidu++;
            }//przejście do slaidu następnego
            else mz_NrSlaidu = 0;

            //Okreslnie maxymalnych rozmiarów powierzchni graficznej  
            int mz_Xmax = imgRysownica.Width;
            int mz_Ymax = imgRysownica.Height;
            mz_LFG[mz_NrSlaidu].mz_PrzesuńDoNowegoXY(imgRysownica, mz_Rysownica, mz_Xmax / 2, mz_Ymax / 2);
            //Uaktualnienie wyświetlanego nr slaidu
            txtNrSlajdu.Text = mz_NrSlaidu.ToString();    
            imgRysownica.Refresh(); 
        }

        private void btnPoprzedni_Click(object sender, EventArgs e)
        {
            int mz_NrSlaidu;
            //Odczyt bierzącego nr slaidu
            if (!int.TryParse(txtNrSlajdu.Text, out mz_NrSlaidu))
            {
                errorProvider1.SetError(txtNrSlajdu, "ERROR: Bledny zapis nr slaidu");
                return;
            }
            errorProvider1.Dispose();
            mz_Rysownica.Clear(txtKolorTła.BackColor);
            imgRysownica.Refresh(); 

            if ((mz_NrSlaidu > 0) && (mz_NrSlaidu < mz_LFG.Count))
            {
                mz_NrSlaidu--;
            }
            else
                mz_NrSlaidu = mz_LFG.Count - 1;
            //Określenie maksymalnych rozmiarów powierzchni graficznej
            int mz_Xmax = imgRysownica.Width;
            int mz_Ymax = imgRysownica.Height;
            mz_LFG[mz_NrSlaidu].mz_PrzesuńDoNowegoXY(imgRysownica, mz_Rysownica, mz_Xmax / 2, mz_Ymax / 2);
            //Uaktualnienie wyświetlanego nr slaidu
            txtNrSlajdu.Text = mz_NrSlaidu.ToString();

            imgRysownica.Refresh(); 
        }

        private void tsZapiszPlik_Click(object sender, EventArgs e)
        {
            SaveFileDialog mz_Plik = new SaveFileDialog();

            if (mz_Plik.ShowDialog() == DialogResult.OK)
            {

                mz_Plik.DefaultExt = "*.bmp";
                mz_Plik.Filter = "Pliki BMP (*.bmp)|*.bmp";

                imgRysownica.Image.Save(mz_Plik.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }

        private void tsOdczytajPlik_Click(object sender, EventArgs e)
        {
            Bitmap mz_image;

            OpenFileDialog mz_open_dialog = new OpenFileDialog();
            mz_open_dialog.Filter = "P(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (mz_open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    mz_image = new Bitmap(mz_open_dialog.FileName);
                    this.imgRysownica.Size = mz_image.Size;
                    imgRysownica.Image = mz_image;
                    imgRysownica.Invalidate();
                    mz_Rysownica.Clear(imgRysownica.BackColor);
                }
                catch
                {
                    DialogResult mz_wynik = MessageBox.Show("Niemozliwe odkryć ten plik",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    }
// Autor programu: Mykola Zahanych

