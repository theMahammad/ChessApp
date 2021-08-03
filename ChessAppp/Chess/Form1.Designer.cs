
namespace Chess
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
            this.pnl_chess_arena = new System.Windows.Forms.Panel();
            this.lbl_focusedFigure = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnl_chess_arena
            // 
            this.pnl_chess_arena.Location = new System.Drawing.Point(171, 23);
            this.pnl_chess_arena.Name = "pnl_chess_arena";
            this.pnl_chess_arena.Size = new System.Drawing.Size(460, 402);
            this.pnl_chess_arena.TabIndex = 0;
            // 
            // lbl_focusedFigure
            // 
            this.lbl_focusedFigure.AutoSize = true;
            this.lbl_focusedFigure.Location = new System.Drawing.Point(36, 162);
            this.lbl_focusedFigure.Name = "lbl_focusedFigure";
            this.lbl_focusedFigure.Size = new System.Drawing.Size(38, 15);
            this.lbl_focusedFigure.TabIndex = 1;
            this.lbl_focusedFigure.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_focusedFigure);
            this.Controls.Add(this.pnl_chess_arena);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_chess_arena;
        private System.Windows.Forms.Label lbl_focusedFigure;
    }
}

