namespace WinForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.заполнитьДанныеСФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выводВОкноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ручнойВводДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заполнитьДанныеСФайлаToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(268, 28);
            // 
            // заполнитьДанныеСФайлаToolStripMenuItem
            // 
            this.заполнитьДанныеСФайлаToolStripMenuItem.Name = "заполнитьДанныеСФайлаToolStripMenuItem";
            this.заполнитьДанныеСФайлаToolStripMenuItem.Size = new System.Drawing.Size(267, 24);
            this.заполнитьДанныеСФайлаToolStripMenuItem.Text = "Заполнить данные с файла";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.выводВОкноToolStripMenuItem,
            this.ручнойВводДанныхToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.экспортФайлToolStripMenuItem,
            this.импортФайлToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // экспортФайлToolStripMenuItem
            // 
            this.экспортФайлToolStripMenuItem.Name = "экспортФайлToolStripMenuItem";
            this.экспортФайлToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.экспортФайлToolStripMenuItem.Text = "Экспорт файл";
            // 
            // импортФайлToolStripMenuItem
            // 
            this.импортФайлToolStripMenuItem.Name = "импортФайлToolStripMenuItem";
            this.импортФайлToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.импортФайлToolStripMenuItem.Text = "Импорт файл";
            // 
            // выводВОкноToolStripMenuItem
            // 
            this.выводВОкноToolStripMenuItem.Name = "выводВОкноToolStripMenuItem";
            this.выводВОкноToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.выводВОкноToolStripMenuItem.Text = "Вывод в окно";
            // 
            // ручнойВводДанныхToolStripMenuItem
            // 
            this.ручнойВводДанныхToolStripMenuItem.Name = "ручнойВводДанныхToolStripMenuItem";
            this.ручнойВводДанныхToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.ручнойВводДанныхToolStripMenuItem.Text = "Ручной ввод данных";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 72);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(369, 340);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem заполнитьДанныеСФайлаToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выводВОкноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ручнойВводДанныхToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

