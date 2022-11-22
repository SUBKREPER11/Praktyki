
namespace Drwale
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Line = new System.Windows.Forms.ListBox();
            this.name = new System.Windows.Forms.TextBox();
            this.nextInLine = new System.Windows.Forms.TextBox();
            this.addLumberjack = new System.Windows.Forms.Button();
            this.addFlapjacks = new System.Windows.Forms.Button();
            this.nextLumberjack = new System.Windows.Forms.Button();
            this.howMany = new System.Windows.Forms.NumericUpDown();
            this.crispy = new System.Windows.Forms.RadioButton();
            this.soggy = new System.Windows.Forms.RadioButton();
            this.browned = new System.Windows.Forms.RadioButton();
            this.banana = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.howMany)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imię drwala";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kolejka do śniadania";
            // 
            // breakfastLine
            // 
            this.Line.FormattingEnabled = true;
            this.Line.Location = new System.Drawing.Point(12, 74);
            this.Line.Name = "breakfastLine";
            this.Line.Size = new System.Drawing.Size(120, 238);
            this.Line.TabIndex = 2;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(78, 9);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(145, 20);
            this.name.TabIndex = 3;
            // 
            // nextInLine
            // 
            this.nextInLine.Location = new System.Drawing.Point(6, 166);
            this.nextInLine.Multiline = true;
            this.nextInLine.Name = "nextInLine";
            this.nextInLine.ReadOnly = true;
            this.nextInLine.Size = new System.Drawing.Size(120, 43);
            this.nextInLine.TabIndex = 4;
            // 
            // addLumberjack
            // 
            this.addLumberjack.Location = new System.Drawing.Point(12, 32);
            this.addLumberjack.Name = "addLumberjack";
            this.addLumberjack.Size = new System.Drawing.Size(211, 23);
            this.addLumberjack.TabIndex = 5;
            this.addLumberjack.Text = "Dodaj drwala";
            this.addLumberjack.UseVisualStyleBackColor = true;
            this.addLumberjack.Click += new System.EventHandler(this.addLumberjack_Click);
            // 
            // addFlapjacks
            // 
            this.addFlapjacks.Location = new System.Drawing.Point(6, 137);
            this.addFlapjacks.Name = "addFlapjacks";
            this.addFlapjacks.Size = new System.Drawing.Size(120, 23);
            this.addFlapjacks.TabIndex = 6;
            this.addFlapjacks.Text = "Dodaj naleśniki";
            this.addFlapjacks.UseVisualStyleBackColor = true;
            this.addFlapjacks.Click += new System.EventHandler(this.addFlapjacks_Click);
            // 
            // nextLumberjack
            // 
            this.nextLumberjack.Location = new System.Drawing.Point(-2, 215);
            this.nextLumberjack.Name = "nextLumberjack";
            this.nextLumberjack.Size = new System.Drawing.Size(133, 23);
            this.nextLumberjack.TabIndex = 7;
            this.nextLumberjack.Text = "Następny drwal!";
            this.nextLumberjack.UseVisualStyleBackColor = true;
            this.nextLumberjack.Click += new System.EventHandler(this.nextLumberjack_Click);
            // 
            // howMany
            // 
            this.howMany.Location = new System.Drawing.Point(6, 19);
            this.howMany.Name = "howMany";
            this.howMany.Size = new System.Drawing.Size(79, 20);
            this.howMany.TabIndex = 8;
            // 
            // crispy
            // 
            this.crispy.AutoSize = true;
            this.crispy.Location = new System.Drawing.Point(6, 45);
            this.crispy.Name = "crispy";
            this.crispy.Size = new System.Drawing.Size(79, 17);
            this.crispy.TabIndex = 9;
            this.crispy.TabStop = true;
            this.crispy.Text = "Chrupkiego";
            this.crispy.UseVisualStyleBackColor = true;
            // 
            // soggy
            // 
            this.soggy.AutoSize = true;
            this.soggy.Location = new System.Drawing.Point(6, 68);
            this.soggy.Name = "soggy";
            this.soggy.Size = new System.Drawing.Size(79, 17);
            this.soggy.TabIndex = 10;
            this.soggy.TabStop = true;
            this.soggy.Text = "Wilgotnego";
            this.soggy.UseVisualStyleBackColor = true;
            // 
            // browned
            // 
            this.browned.AutoSize = true;
            this.browned.Location = new System.Drawing.Point(6, 91);
            this.browned.Name = "browned";
            this.browned.Size = new System.Drawing.Size(79, 17);
            this.browned.TabIndex = 11;
            this.browned.TabStop = true;
            this.browned.Text = "Rumianego";
            this.browned.UseVisualStyleBackColor = true;
            // 
            // banana
            // 
            this.banana.AutoSize = true;
            this.banana.Location = new System.Drawing.Point(6, 114);
            this.banana.Name = "banana";
            this.banana.Size = new System.Drawing.Size(88, 17);
            this.banana.TabIndex = 12;
            this.banana.TabStop = true;
            this.banana.Text = "Bananowego";
            this.banana.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.howMany);
            this.groupBox1.Controls.Add(this.nextLumberjack);
            this.groupBox1.Controls.Add(this.banana);
            this.groupBox1.Controls.Add(this.addFlapjacks);
            this.groupBox1.Controls.Add(this.nextInLine);
            this.groupBox1.Controls.Add(this.crispy);
            this.groupBox1.Controls.Add(this.browned);
            this.groupBox1.Controls.Add(this.soggy);
            this.groupBox1.Location = new System.Drawing.Point(138, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 238);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nakarm drwala";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 323);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addLumberjack);
            this.Controls.Add(this.name);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Śniadanie dla drwali";
            ((System.ComponentModel.ISupportInitialize)(this.howMany)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Line;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox nextInLine;
        private System.Windows.Forms.Button addLumberjack;
        private System.Windows.Forms.Button addFlapjacks;
        private System.Windows.Forms.Button nextLumberjack;
        private System.Windows.Forms.NumericUpDown howMany;
        private System.Windows.Forms.RadioButton crispy;
        private System.Windows.Forms.RadioButton soggy;
        private System.Windows.Forms.RadioButton browned;
        private System.Windows.Forms.RadioButton banana;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

