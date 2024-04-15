namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            labelResult = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(11, 117);
            button1.Name = "button1";
            button1.Size = new Size(484, 40);
            button1.TabIndex = 0;
            button1.Text = "Расчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(11, 88);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(484, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 70);
            label1.Name = "label1";
            label1.Size = new Size(485, 15);
            label1.TabIndex = 2;
            label1.Text = "Введите натуральное число от 1 до 9999, определяющее стоимость товара в копейках:";
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(12, 160);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(119, 15);
            labelResult.TabIndex = 3;
            labelResult.Text = "Ожидание расчёта...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(462, 45);
            label2.TabIndex = 4;
            label2.Text = "Дано натуральное число 1≤n≤9999, определяющее стоимость товара в копейках. \r\nВыразить стоимость в рублях и копейках, \r\nнапример, 3 рубля 21 копейка, 15 рублей 5 копеек, 1 рубль ровно и т. п.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 189);
            Controls.Add(label2);
            Controls.Add(labelResult);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Форматирование копеек";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Label labelResult;
        private Label label2;
    }
}