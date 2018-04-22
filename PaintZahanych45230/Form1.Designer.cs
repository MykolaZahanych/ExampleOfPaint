namespace PaintZahanych45230
{
    partial class PaintZahanych45230
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsZapiszPlik = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOdczytajPlik = new System.Windows.Forms.ToolStripMenuItem();
            this.przesuneńDoNowegoXYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbGumka = new System.Windows.Forms.RadioButton();
            this.rdbKwadratJednobarwny = new System.Windows.Forms.RadioButton();
            this.rdbProstokątJednobarwny = new System.Windows.Forms.RadioButton();
            this.rdbKołoJednobarwne = new System.Windows.Forms.RadioButton();
            this.rdbLiniaProsta = new System.Windows.Forms.RadioButton();
            this.rdbKwadrat = new System.Windows.Forms.RadioButton();
            this.rdbElipsa = new System.Windows.Forms.RadioButton();
            this.rdbProstokąt = new System.Windows.Forms.RadioButton();
            this.rdbPunkt = new System.Windows.Forms.RadioButton();
            this.rdbOkrąg = new System.Windows.Forms.RadioButton();
            this.imgRysownica = new System.Windows.Forms.PictureBox();
            this.btnZmianaKolLinii = new System.Windows.Forms.Button();
            this.btnZmianaKolRysownicy = new System.Windows.Forms.Button();
            this.txtKolorTła = new System.Windows.Forms.TextBox();
            this.cmbStylLinii = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trbSuwakGrubośćLinii = new System.Windows.Forms.TrackBar();
            this.txtGrubośćLinii = new System.Windows.Forms.TextBox();
            this.txtKolorLinii = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWspX = new System.Windows.Forms.Label();
            this.lblWspY = new System.Windows.Forms.Label();
            this.btnPrzesuńFigury = new System.Windows.Forms.Button();
            this.btnLosowaZmianaAtrybutów = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudGrubość = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtNrSlajdu = new System.Windows.Forms.TextBox();
            this.btnNastępny = new System.Windows.Forms.Button();
            this.btnPoprzedni = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgRysownica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSuwakGrubośćLinii)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGrubość)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.przesuneńDoNowegoXYToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1469, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsZapiszPlik,
            this.tsOdczytajPlik});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.plikToolStripMenuItem.Text = "Plik ";
            // 
            // tsZapiszPlik
            // 
            this.tsZapiszPlik.Name = "tsZapiszPlik";
            this.tsZapiszPlik.Size = new System.Drawing.Size(170, 26);
            this.tsZapiszPlik.Text = "Zapisz w plik";
            this.tsZapiszPlik.Click += new System.EventHandler(this.tsZapiszPlik_Click);
            // 
            // tsOdczytajPlik
            // 
            this.tsOdczytajPlik.Name = "tsOdczytajPlik";
            this.tsOdczytajPlik.Size = new System.Drawing.Size(170, 26);
            this.tsOdczytajPlik.Text = "Odczytaj Plik";
            this.tsOdczytajPlik.Click += new System.EventHandler(this.tsOdczytajPlik_Click);
            // 
            // przesuneńDoNowegoXYToolStripMenuItem
            // 
            this.przesuneńDoNowegoXYToolStripMenuItem.Name = "przesuneńDoNowegoXYToolStripMenuItem";
            this.przesuneńDoNowegoXYToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.przesuneńDoNowegoXYToolStripMenuItem.Text = "Przesuneń do nowego XY";
            this.przesuneńDoNowegoXYToolStripMenuItem.Click += new System.EventHandler(this.przesuneńDoNowegoXYToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbGumka);
            this.groupBox1.Controls.Add(this.rdbKwadratJednobarwny);
            this.groupBox1.Controls.Add(this.rdbProstokątJednobarwny);
            this.groupBox1.Controls.Add(this.rdbKołoJednobarwne);
            this.groupBox1.Controls.Add(this.rdbLiniaProsta);
            this.groupBox1.Controls.Add(this.rdbKwadrat);
            this.groupBox1.Controls.Add(this.rdbElipsa);
            this.groupBox1.Controls.Add(this.rdbProstokąt);
            this.groupBox1.Controls.Add(this.rdbPunkt);
            this.groupBox1.Controls.Add(this.rdbOkrąg);
            this.groupBox1.Location = new System.Drawing.Point(15, 599);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1431, 81);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plaskie figury geometryczne ";
            // 
            // rdbGumka
            // 
            this.rdbGumka.AutoSize = true;
            this.rdbGumka.Location = new System.Drawing.Point(1167, 34);
            this.rdbGumka.Name = "rdbGumka";
            this.rdbGumka.Size = new System.Drawing.Size(74, 21);
            this.rdbGumka.TabIndex = 12;
            this.rdbGumka.TabStop = true;
            this.rdbGumka.Text = "Gumka";
            this.rdbGumka.UseVisualStyleBackColor = true;
            // 
            // rdbKwadratJednobarwny
            // 
            this.rdbKwadratJednobarwny.AutoSize = true;
            this.rdbKwadratJednobarwny.Location = new System.Drawing.Point(638, 34);
            this.rdbKwadratJednobarwny.Name = "rdbKwadratJednobarwny";
            this.rdbKwadratJednobarwny.Size = new System.Drawing.Size(168, 21);
            this.rdbKwadratJednobarwny.TabIndex = 11;
            this.rdbKwadratJednobarwny.TabStop = true;
            this.rdbKwadratJednobarwny.Text = "Kwadrat Jednobarwny";
            this.rdbKwadratJednobarwny.UseVisualStyleBackColor = true;
            // 
            // rdbProstokątJednobarwny
            // 
            this.rdbProstokątJednobarwny.AutoSize = true;
            this.rdbProstokątJednobarwny.Location = new System.Drawing.Point(964, 34);
            this.rdbProstokątJednobarwny.Name = "rdbProstokątJednobarwny";
            this.rdbProstokątJednobarwny.Size = new System.Drawing.Size(177, 21);
            this.rdbProstokątJednobarwny.TabIndex = 10;
            this.rdbProstokątJednobarwny.TabStop = true;
            this.rdbProstokątJednobarwny.Text = "Prostokąt Jednobarwny";
            this.rdbProstokątJednobarwny.UseVisualStyleBackColor = true;
            // 
            // rdbKołoJednobarwne
            // 
            this.rdbKołoJednobarwne.AutoSize = true;
            this.rdbKołoJednobarwne.Location = new System.Drawing.Point(812, 34);
            this.rdbKołoJednobarwne.Name = "rdbKołoJednobarwne";
            this.rdbKołoJednobarwne.Size = new System.Drawing.Size(146, 21);
            this.rdbKołoJednobarwne.TabIndex = 9;
            this.rdbKołoJednobarwne.TabStop = true;
            this.rdbKołoJednobarwne.Text = "Koło Jednobarwne";
            this.rdbKołoJednobarwne.UseVisualStyleBackColor = true;
            // 
            // rdbLiniaProsta
            // 
            this.rdbLiniaProsta.AutoSize = true;
            this.rdbLiniaProsta.Location = new System.Drawing.Point(522, 34);
            this.rdbLiniaProsta.Name = "rdbLiniaProsta";
            this.rdbLiniaProsta.Size = new System.Drawing.Size(108, 21);
            this.rdbLiniaProsta.TabIndex = 3;
            this.rdbLiniaProsta.TabStop = true;
            this.rdbLiniaProsta.Text = "Linia Prosta ";
            this.rdbLiniaProsta.UseVisualStyleBackColor = true;
            // 
            // rdbKwadrat
            // 
            this.rdbKwadrat.AutoSize = true;
            this.rdbKwadrat.Location = new System.Drawing.Point(399, 32);
            this.rdbKwadrat.Name = "rdbKwadrat";
            this.rdbKwadrat.Size = new System.Drawing.Size(84, 21);
            this.rdbKwadrat.TabIndex = 6;
            this.rdbKwadrat.TabStop = true;
            this.rdbKwadrat.Text = "Kwadrat ";
            this.rdbKwadrat.UseVisualStyleBackColor = true;
            // 
            // rdbElipsa
            // 
            this.rdbElipsa.AutoSize = true;
            this.rdbElipsa.Location = new System.Drawing.Point(123, 34);
            this.rdbElipsa.Name = "rdbElipsa";
            this.rdbElipsa.Size = new System.Drawing.Size(71, 21);
            this.rdbElipsa.TabIndex = 3;
            this.rdbElipsa.TabStop = true;
            this.rdbElipsa.Text = "Elipsa ";
            this.rdbElipsa.UseVisualStyleBackColor = true;
            // 
            // rdbProstokąt
            // 
            this.rdbProstokąt.AutoSize = true;
            this.rdbProstokąt.Location = new System.Drawing.Point(292, 34);
            this.rdbProstokąt.Name = "rdbProstokąt";
            this.rdbProstokąt.Size = new System.Drawing.Size(89, 21);
            this.rdbProstokąt.TabIndex = 5;
            this.rdbProstokąt.TabStop = true;
            this.rdbProstokąt.Text = "Prostokąt";
            this.rdbProstokąt.UseVisualStyleBackColor = true;
            // 
            // rdbPunkt
            // 
            this.rdbPunkt.AutoSize = true;
            this.rdbPunkt.Location = new System.Drawing.Point(35, 34);
            this.rdbPunkt.Name = "rdbPunkt";
            this.rdbPunkt.Size = new System.Drawing.Size(69, 21);
            this.rdbPunkt.TabIndex = 2;
            this.rdbPunkt.TabStop = true;
            this.rdbPunkt.Text = "Punkt ";
            this.rdbPunkt.UseVisualStyleBackColor = true;
            // 
            // rdbOkrąg
            // 
            this.rdbOkrąg.AutoSize = true;
            this.rdbOkrąg.Location = new System.Drawing.Point(200, 34);
            this.rdbOkrąg.Name = "rdbOkrąg";
            this.rdbOkrąg.Size = new System.Drawing.Size(68, 21);
            this.rdbOkrąg.TabIndex = 4;
            this.rdbOkrąg.TabStop = true;
            this.rdbOkrąg.Text = "Okrąg";
            this.rdbOkrąg.UseVisualStyleBackColor = true;
            // 
            // imgRysownica
            // 
            this.imgRysownica.Location = new System.Drawing.Point(55, 86);
            this.imgRysownica.Name = "imgRysownica";
            this.imgRysownica.Size = new System.Drawing.Size(792, 373);
            this.imgRysownica.TabIndex = 2;
            this.imgRysownica.TabStop = false;
            this.imgRysownica.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgRysownica_MouseDown);
            this.imgRysownica.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgRysownica_MouseMove);
            this.imgRysownica.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgRysownica_MouseUp);
            // 
            // btnZmianaKolLinii
            // 
            this.btnZmianaKolLinii.Location = new System.Drawing.Point(1143, 75);
            this.btnZmianaKolLinii.Name = "btnZmianaKolLinii";
            this.btnZmianaKolLinii.Size = new System.Drawing.Size(157, 39);
            this.btnZmianaKolLinii.TabIndex = 3;
            this.btnZmianaKolLinii.Text = "Zmiana koloru linii ";
            this.btnZmianaKolLinii.UseVisualStyleBackColor = true;
            this.btnZmianaKolLinii.Click += new System.EventHandler(this.btnZmianaKolLinii_Click);
            // 
            // btnZmianaKolRysownicy
            // 
            this.btnZmianaKolRysownicy.Location = new System.Drawing.Point(1143, 186);
            this.btnZmianaKolRysownicy.Name = "btnZmianaKolRysownicy";
            this.btnZmianaKolRysownicy.Size = new System.Drawing.Size(157, 52);
            this.btnZmianaKolRysownicy.TabIndex = 5;
            this.btnZmianaKolRysownicy.Text = "Zmiana koloru tła \r\nrysownicy ";
            this.btnZmianaKolRysownicy.UseVisualStyleBackColor = true;
            this.btnZmianaKolRysownicy.Click += new System.EventHandler(this.btnZmianaKolRysownicy_Click);
            // 
            // txtKolorTła
            // 
            this.txtKolorTła.BackColor = System.Drawing.Color.SandyBrown;
            this.txtKolorTła.Location = new System.Drawing.Point(1143, 267);
            this.txtKolorTła.Name = "txtKolorTła";
            this.txtKolorTła.ReadOnly = true;
            this.txtKolorTła.Size = new System.Drawing.Size(157, 22);
            this.txtKolorTła.TabIndex = 6;
            // 
            // cmbStylLinii
            // 
            this.cmbStylLinii.FormattingEnabled = true;
            this.cmbStylLinii.Items.AddRange(new object[] {
            "Kreskowa (Dash)",
            "KreskowaKropkowa (DashDot)",
            "KreskowaKropkowaKropkowa(DashDotDot)",
            "Kropkowa(Dot)",
            "Ciągła(Solid)"});
            this.cmbStylLinii.Location = new System.Drawing.Point(1318, 318);
            this.cmbStylLinii.Name = "cmbStylLinii";
            this.cmbStylLinii.Size = new System.Drawing.Size(121, 24);
            this.cmbStylLinii.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1306, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ustaw Grubość Linii ";
            // 
            // trbSuwakGrubośćLinii
            // 
            this.trbSuwakGrubośćLinii.Location = new System.Drawing.Point(1309, 124);
            this.trbSuwakGrubośćLinii.Name = "trbSuwakGrubośćLinii";
            this.trbSuwakGrubośćLinii.Size = new System.Drawing.Size(125, 56);
            this.trbSuwakGrubośćLinii.TabIndex = 9;
            this.trbSuwakGrubośćLinii.Scroll += new System.EventHandler(this.trbSuwakGrubośćLinii_Scroll);
            // 
            // txtGrubośćLinii
            // 
            this.txtGrubośćLinii.Location = new System.Drawing.Point(1318, 201);
            this.txtGrubośćLinii.Name = "txtGrubośćLinii";
            this.txtGrubośćLinii.ReadOnly = true;
            this.txtGrubośćLinii.Size = new System.Drawing.Size(116, 22);
            this.txtGrubośćLinii.TabIndex = 10;
            // 
            // txtKolorLinii
            // 
            this.txtKolorLinii.BackColor = System.Drawing.Color.Black;
            this.txtKolorLinii.Location = new System.Drawing.Point(1146, 124);
            this.txtKolorLinii.Name = "txtKolorLinii";
            this.txtKolorLinii.ReadOnly = true;
            this.txtKolorLinii.Size = new System.Drawing.Size(157, 22);
            this.txtKolorLinii.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Współrzędne aktualnego polożenia myszy (X, Y)";
            // 
            // lblWspX
            // 
            this.lblWspX.AutoSize = true;
            this.lblWspX.Location = new System.Drawing.Point(347, 41);
            this.lblWspX.Name = "lblWspX";
            this.lblWspX.Size = new System.Drawing.Size(100, 17);
            this.lblWspX.TabIndex = 13;
            this.lblWspX.Text = "współrzędna X";
            // 
            // lblWspY
            // 
            this.lblWspY.AutoSize = true;
            this.lblWspY.Location = new System.Drawing.Point(478, 41);
            this.lblWspY.Name = "lblWspY";
            this.lblWspY.Size = new System.Drawing.Size(100, 17);
            this.lblWspY.TabIndex = 14;
            this.lblWspY.Text = "współrzędna Y";
            // 
            // btnPrzesuńFigury
            // 
            this.btnPrzesuńFigury.Location = new System.Drawing.Point(1146, 307);
            this.btnPrzesuńFigury.Name = "btnPrzesuńFigury";
            this.btnPrzesuńFigury.Size = new System.Drawing.Size(157, 67);
            this.btnPrzesuńFigury.TabIndex = 15;
            this.btnPrzesuńFigury.Text = "Wylosuj nowe położenia";
            this.btnPrzesuńFigury.UseVisualStyleBackColor = true;
            this.btnPrzesuńFigury.Click += new System.EventHandler(this.btnPrzesuńFigury_Click);
            // 
            // btnLosowaZmianaAtrybutów
            // 
            this.btnLosowaZmianaAtrybutów.Location = new System.Drawing.Point(1146, 415);
            this.btnLosowaZmianaAtrybutów.Name = "btnLosowaZmianaAtrybutów";
            this.btnLosowaZmianaAtrybutów.Size = new System.Drawing.Size(157, 76);
            this.btnLosowaZmianaAtrybutów.TabIndex = 16;
            this.btnLosowaZmianaAtrybutów.Text = "Wylosuj nowe atrybuty graficzne \r\nfigur geometrycznych";
            this.btnLosowaZmianaAtrybutów.UseVisualStyleBackColor = true;
            this.btnLosowaZmianaAtrybutów.Click += new System.EventHandler(this.btnLosowaZmianaAtrybutów_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1309, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ustawiona Grubość Linii ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1309, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Ustaw Grubość Linii ";
            // 
            // nudGrubość
            // 
            this.nudGrubość.Location = new System.Drawing.Point(1318, 257);
            this.nudGrubość.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudGrubość.Name = "nudGrubość";
            this.nudGrubość.Size = new System.Drawing.Size(120, 22);
            this.nudGrubość.TabIndex = 19;
            this.nudGrubość.ValueChanged += new System.EventHandler(this.nudGrubość_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1312, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Ustaw Styl Linii ";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tag = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1315, 357);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Indeks figur ( slajdu)";
            // 
            // txtNrSlajdu
            // 
            this.txtNrSlajdu.Location = new System.Drawing.Point(1318, 383);
            this.txtNrSlajdu.Name = "txtNrSlajdu";
            this.txtNrSlajdu.Size = new System.Drawing.Size(133, 22);
            this.txtNrSlajdu.TabIndex = 22;
            // 
            // btnNastępny
            // 
            this.btnNastępny.Location = new System.Drawing.Point(1318, 415);
            this.btnNastępny.Name = "btnNastępny";
            this.btnNastępny.Size = new System.Drawing.Size(93, 44);
            this.btnNastępny.TabIndex = 23;
            this.btnNastępny.Text = "Następny ";
            this.btnNastępny.UseVisualStyleBackColor = true;
            this.btnNastępny.Click += new System.EventHandler(this.btnNastępny_Click);
            // 
            // btnPoprzedni
            // 
            this.btnPoprzedni.Location = new System.Drawing.Point(1318, 474);
            this.btnPoprzedni.Name = "btnPoprzedni";
            this.btnPoprzedni.Size = new System.Drawing.Size(93, 44);
            this.btnPoprzedni.TabIndex = 24;
            this.btnPoprzedni.Text = "Poprzedni";
            this.btnPoprzedni.UseVisualStyleBackColor = true;
            this.btnPoprzedni.Click += new System.EventHandler(this.btnPoprzedni_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PaintZahanych45230
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 693);
            this.Controls.Add(this.btnPoprzedni);
            this.Controls.Add(this.btnNastępny);
            this.Controls.Add(this.txtNrSlajdu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudGrubość);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLosowaZmianaAtrybutów);
            this.Controls.Add(this.btnPrzesuńFigury);
            this.Controls.Add(this.lblWspY);
            this.Controls.Add(this.lblWspX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKolorLinii);
            this.Controls.Add(this.txtGrubośćLinii);
            this.Controls.Add(this.trbSuwakGrubośćLinii);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStylLinii);
            this.Controls.Add(this.txtKolorTła);
            this.Controls.Add(this.btnZmianaKolRysownicy);
            this.Controls.Add(this.btnZmianaKolLinii);
            this.Controls.Add(this.imgRysownica);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PaintZahanych45230";
            this.Text = "PaintZahanych45230";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgRysownica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSuwakGrubośćLinii)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGrubość)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem przesuneńDoNowegoXYToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbLiniaProsta;
        private System.Windows.Forms.RadioButton rdbKwadrat;
        private System.Windows.Forms.RadioButton rdbElipsa;
        private System.Windows.Forms.RadioButton rdbProstokąt;
        private System.Windows.Forms.RadioButton rdbPunkt;
        private System.Windows.Forms.RadioButton rdbOkrąg;
        private System.Windows.Forms.PictureBox imgRysownica;
        private System.Windows.Forms.Button btnZmianaKolLinii;
        private System.Windows.Forms.Button btnZmianaKolRysownicy;
        private System.Windows.Forms.TextBox txtKolorTła;
        private System.Windows.Forms.ComboBox cmbStylLinii;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trbSuwakGrubośćLinii;
        protected internal System.Windows.Forms.TextBox txtGrubośćLinii;
        private System.Windows.Forms.TextBox txtKolorLinii;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWspX;
        private System.Windows.Forms.Label lblWspY;
        private System.Windows.Forms.Button btnPrzesuńFigury;
        private System.Windows.Forms.Button btnLosowaZmianaAtrybutów;
        private System.Windows.Forms.RadioButton rdbKołoJednobarwne;
        private System.Windows.Forms.RadioButton rdbProstokątJednobarwny;
        private System.Windows.Forms.RadioButton rdbKwadratJednobarwny;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudGrubość;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNrSlajdu;
        private System.Windows.Forms.Button btnNastępny;
        private System.Windows.Forms.Button btnPoprzedni;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.RadioButton rdbGumka;
        private System.Windows.Forms.ToolStripMenuItem tsZapiszPlik;
        private System.Windows.Forms.ToolStripMenuItem tsOdczytajPlik;
    }
}

