namespace interview_assist {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            lblDevice = new Label();
            cboDevice = new ComboBox();
            butStartStop = new Button();
            txtQuestion = new TextBox();
            lblQuestion = new Label();
            lblAnswer = new Label();
            txtAnswer = new TextBox();
            butResponse = new Button();
            butClear = new Button();
            SuspendLayout();
            // 
            // lblDevice
            // 
            lblDevice.AutoSize = true;
            lblDevice.Location = new Point(15, 15);
            lblDevice.Name = "lblDevice";
            lblDevice.Size = new Size(48, 15);
            lblDevice.TabIndex = 0;
            lblDevice.Text = "Device :";
            // 
            // cboDevice
            // 
            cboDevice.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDevice.FormattingEnabled = true;
            cboDevice.Location = new Point(69, 12);
            cboDevice.Name = "cboDevice";
            cboDevice.Size = new Size(314, 23);
            cboDevice.TabIndex = 1;
            // 
            // butStartStop
            // 
            butStartStop.Location = new Point(389, 11);
            butStartStop.Name = "butStartStop";
            butStartStop.Size = new Size(79, 25);
            butStartStop.TabIndex = 2;
            butStartStop.Text = "Start";
            butStartStop.UseVisualStyleBackColor = true;
            butStartStop.Click += butStartStop_Click;
            // 
            // txtQuestion
            // 
            txtQuestion.Location = new Point(20, 75);
            txtQuestion.Multiline = true;
            txtQuestion.Name = "txtQuestion";
            txtQuestion.ScrollBars = ScrollBars.Vertical;
            txtQuestion.Size = new Size(448, 83);
            txtQuestion.TabIndex = 3;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(15, 48);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(61, 15);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "Question :";
            // 
            // lblAnswer
            // 
            lblAnswer.AutoSize = true;
            lblAnswer.Location = new Point(15, 174);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(52, 15);
            lblAnswer.TabIndex = 0;
            lblAnswer.Text = "Answer :";
            // 
            // txtAnswer
            // 
            txtAnswer.BackColor = Color.Black;
            txtAnswer.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtAnswer.ForeColor = Color.White;
            txtAnswer.Location = new Point(20, 201);
            txtAnswer.Multiline = true;
            txtAnswer.Name = "txtAnswer";
            txtAnswer.ScrollBars = ScrollBars.Vertical;
            txtAnswer.Size = new Size(448, 414);
            txtAnswer.TabIndex = 3;
            // 
            // butResponse
            // 
            butResponse.Location = new Point(389, 168);
            butResponse.Name = "butResponse";
            butResponse.Size = new Size(79, 25);
            butResponse.TabIndex = 2;
            butResponse.Text = "Response";
            butResponse.UseVisualStyleBackColor = true;
            butResponse.Click += butResponse_Click;
            // 
            // butClear
            // 
            butClear.Location = new Point(304, 168);
            butClear.Name = "butClear";
            butClear.Size = new Size(79, 25);
            butClear.TabIndex = 2;
            butClear.Text = "Clear";
            butClear.UseVisualStyleBackColor = true;
            butClear.Click += butClear_Click;
            // 
            // MainForm
            // 
            AcceptButton = butResponse;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = butClear;
            ClientSize = new Size(486, 630);
            Controls.Add(txtAnswer);
            Controls.Add(txtQuestion);
            Controls.Add(butClear);
            Controls.Add(butResponse);
            Controls.Add(butStartStop);
            Controls.Add(cboDevice);
            Controls.Add(lblAnswer);
            Controls.Add(lblQuestion);
            Controls.Add(lblDevice);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Interview Assist";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDevice;
        private ComboBox cboDevice;
        private Button butStartStop;
        private TextBox txtQuestion;
        private Label lblQuestion;
        private Label lblAnswer;
        private TextBox txtAnswer;
        private Button butResponse;
        private Button butClear;
    }
}