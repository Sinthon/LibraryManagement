
namespace LibraryManagement.Views.Books.Dialog
{
    partial class BookDialogView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dialogtitle = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.category = new System.Windows.Forms.ComboBox();
            this.cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.page = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.publisher = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.publish_date = new System.Windows.Forms.DateTimePicker();
            this.ErrorMessage = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.dialogtitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 38);
            this.panel1.TabIndex = 0;
            // 
            // dialogtitle
            // 
            this.dialogtitle.AutoSize = true;
            this.dialogtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogtitle.Location = new System.Drawing.Point(12, 7);
            this.dialogtitle.Name = "dialogtitle";
            this.dialogtitle.Size = new System.Drawing.Size(122, 24);
            this.dialogtitle.TabIndex = 1;
            this.dialogtitle.Text = "Book Dialog";
            // 
            // id
            // 
            this.id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id.Location = new System.Drawing.Point(87, 69);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(142, 20);
            this.id.TabIndex = 12;
            this.id.Text = "0";
            this.id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // category
            // 
            this.category.FormattingEnabled = true;
            this.category.Location = new System.Drawing.Point(307, 138);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(142, 21);
            this.category.TabIndex = 11;
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Location = new System.Drawing.Point(19, 240);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(100, 25);
            this.cancel.TabIndex = 10;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Category";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Title";
            // 
            // title
            // 
            this.title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.title.Location = new System.Drawing.Point(307, 69);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(142, 20);
            this.title.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Page";
            // 
            // page
            // 
            this.page.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.page.Location = new System.Drawing.Point(87, 104);
            this.page.Name = "page";
            this.page.Size = new System.Drawing.Size(142, 20);
            this.page.TabIndex = 12;
            this.page.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Publish date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Publisher";
            // 
            // publisher
            // 
            this.publisher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.publisher.Location = new System.Drawing.Point(307, 102);
            this.publisher.Name = "publisher";
            this.publisher.Size = new System.Drawing.Size(142, 20);
            this.publisher.TabIndex = 12;
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Location = new System.Drawing.Point(349, 240);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(100, 25);
            this.save.TabIndex = 10;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            // 
            // publish_date
            // 
            this.publish_date.AccessibleRole = System.Windows.Forms.AccessibleRole.PropertyPage;
            this.publish_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.publish_date.Location = new System.Drawing.Point(87, 141);
            this.publish_date.Name = "publish_date";
            this.publish_date.Size = new System.Drawing.Size(142, 20);
            this.publish_date.TabIndex = 14;
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.ErrorMessage.Location = new System.Drawing.Point(19, 174);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.ReadOnly = true;
            this.ErrorMessage.Size = new System.Drawing.Size(430, 52);
            this.ErrorMessage.TabIndex = 15;
            this.ErrorMessage.Text = "";
            // 
            // BookDialogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.ErrorMessage);
            this.Controls.Add(this.publish_date);
            this.Controls.Add(this.publisher);
            this.Controls.Add(this.page);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.id);
            this.Controls.Add(this.category);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.save);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 320);
            this.Name = "BookDialogView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label dialogtitle;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.ComboBox category;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox page;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox publisher;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.DateTimePicker publish_date;
        private System.Windows.Forms.RichTextBox ErrorMessage;
    }
}