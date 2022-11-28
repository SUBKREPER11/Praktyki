
namespace menedzer_plac
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.openWorkersListFile = new System.Windows.Forms.Button();
            this.workersList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.workerName = new System.Windows.Forms.Label();
            this.accNum = new System.Windows.Forms.Label();
            this.plc = new System.Windows.Forms.Label();
            this.wrkStrtDat = new System.Windows.Forms.Label();
            this.bon = new System.Windows.Forms.Label();
            this.payCheck = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openWorkersListFile
            // 
            this.openWorkersListFile.Location = new System.Drawing.Point(6, 19);
            this.openWorkersListFile.Name = "openWorkersListFile";
            this.openWorkersListFile.Size = new System.Drawing.Size(120, 23);
            this.openWorkersListFile.TabIndex = 0;
            this.openWorkersListFile.Text = "Otwórz plik listy";
            this.openWorkersListFile.UseVisualStyleBackColor = true;
            this.openWorkersListFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // workersList
            // 
            this.workersList.FormattingEnabled = true;
            this.workersList.Location = new System.Drawing.Point(6, 92);
            this.workersList.Name = "workersList";
            this.workersList.Size = new System.Drawing.Size(120, 173);
            this.workersList.TabIndex = 6;
            this.workersList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.workersList);
            this.groupBox1.Controls.Add(this.openWorkersListFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 271);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pracownicy";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.payCheck);
            this.groupBox2.Controls.Add(this.bon);
            this.groupBox2.Controls.Add(this.wrkStrtDat);
            this.groupBox2.Controls.Add(this.plc);
            this.groupBox2.Controls.Add(this.accNum);
            this.groupBox2.Controls.Add(this.workerName);
            this.groupBox2.Location = new System.Drawing.Point(150, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 230);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dane pracownika";
            // 
            // workerName
            // 
            this.workerName.AutoSize = true;
            this.workerName.Location = new System.Drawing.Point(6, 19);
            this.workerName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.workerName.Name = "workerName";
            this.workerName.Size = new System.Drawing.Size(87, 13);
            this.workerName.TabIndex = 0;
            this.workerName.Text = "Imie pracownika:";
            // 
            // accNum
            // 
            this.accNum.AutoSize = true;
            this.accNum.Location = new System.Drawing.Point(6, 42);
            this.accNum.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.accNum.Name = "accNum";
            this.accNum.Size = new System.Drawing.Size(71, 13);
            this.accNum.TabIndex = 1;
            this.accNum.Text = "Numer konta:";
            // 
            // plc
            // 
            this.plc.AutoSize = true;
            this.plc.Location = new System.Drawing.Point(6, 65);
            this.plc.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.plc.Name = "plc";
            this.plc.Size = new System.Drawing.Size(65, 13);
            this.plc.TabIndex = 2;
            this.plc.Text = "Stanowisko:";
            // 
            // wrkStrtDat
            // 
            this.wrkStrtDat.AutoSize = true;
            this.wrkStrtDat.Location = new System.Drawing.Point(6, 88);
            this.wrkStrtDat.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.wrkStrtDat.Name = "wrkStrtDat";
            this.wrkStrtDat.Size = new System.Drawing.Size(93, 13);
            this.wrkStrtDat.TabIndex = 3;
            this.wrkStrtDat.Text = "Data zatrudnienia:";
            // 
            // bon
            // 
            this.bon.AutoSize = true;
            this.bon.Location = new System.Drawing.Point(6, 111);
            this.bon.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.bon.Name = "bon";
            this.bon.Size = new System.Drawing.Size(40, 13);
            this.bon.TabIndex = 4;
            this.bon.Text = "Bonus:";
            // 
            // payCheck
            // 
            this.payCheck.AutoSize = true;
            this.payCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.payCheck.Location = new System.Drawing.Point(6, 201);
            this.payCheck.Name = "payCheck";
            this.payCheck.Size = new System.Drawing.Size(84, 20);
            this.payCheck.TabIndex = 5;
            this.payCheck.Text = "Wypłata: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Wyszukaj pracownika:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openWorkersListFile;
        private System.Windows.Forms.ListBox workersList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label workerName;
        private System.Windows.Forms.Label accNum;
        private System.Windows.Forms.Label plc;
        private System.Windows.Forms.Label wrkStrtDat;
        private System.Windows.Forms.Label bon;
        private System.Windows.Forms.Label payCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

