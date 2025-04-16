namespace afd_porta_automatica
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            pbDoorPosition = new ProgressBar();
            lblStatus = new Label();
            btnPresence = new Button();
            btnAbsence = new Button();
            btnObstacle = new Button();
            movementTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();

            // pbDoorPosition
            pbDoorPosition.Location = new Point(12, 12);
            pbDoorPosition.Name = "pbDoorPosition";
            pbDoorPosition.Size = new Size(360, 30);
            pbDoorPosition.TabIndex = 0;

            // lblStatus
            lblStatus.AutoSize = false;
            lblStatus.Location = new Point(12, 55);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(360, 20);
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.TabIndex = 1;

            // btnPresence
            btnPresence.Location = new Point(12, 100);
            btnPresence.Name = "btnPresence";
            btnPresence.Size = new Size(120, 40);
            btnPresence.TabIndex = 2;
            btnPresence.Text = "Presença";
            btnPresence.UseVisualStyleBackColor = true;
            btnPresence.Click += btnPresence_Click;

            // btnAbsence
            btnAbsence.Location = new Point(138, 100);
            btnAbsence.Name = "btnAbsence";
            btnAbsence.Size = new Size(120, 40);
            btnAbsence.TabIndex = 3;
            btnAbsence.Text = "Ausência";
            btnAbsence.UseVisualStyleBackColor = true;
            btnAbsence.Click += btnAbsence_Click;

            // btnObstacle
            btnObstacle.Location = new Point(264, 100);
            btnObstacle.Name = "btnObstacle";
            btnObstacle.Size = new Size(120, 40);
            btnObstacle.TabIndex = 4;
            btnObstacle.Text = "Obstáculo";
            btnObstacle.UseVisualStyleBackColor = true;
            btnObstacle.Click += btnObstacle_Click;

            // movementTimer
            movementTimer.Interval = 500;
            movementTimer.Tick += movementTimer_Tick;

            // MainForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 160);
            Controls.Add(btnObstacle);
            Controls.Add(btnAbsence);
            Controls.Add(btnPresence);
            Controls.Add(lblStatus);
            Controls.Add(pbDoorPosition);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Porta Automática";
            ResumeLayout(false);
        }


        #endregion

        private ProgressBar pbDoorPosition;
        private Label lblStatus;
        private Button btnPresence;
        private Button btnAbsence;
        private Button btnObstacle;
        private System.Windows.Forms.Timer movementTimer;
    }
}
