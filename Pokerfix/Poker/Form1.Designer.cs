﻿namespace Poker
{
    partial class Form1
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
            this.bFold = new System.Windows.Forms.Button();
            this.bCheck = new System.Windows.Forms.Button();
            this.bCall = new System.Windows.Forms.Button();
            this.bRaise = new System.Windows.Forms.Button();
            this.pbTimer = new System.Windows.Forms.ProgressBar();
            this.tbPlayerChips = new System.Windows.Forms.TextBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.tbAdd = new System.Windows.Forms.TextBox();
            this.tbBotFiveChips = new System.Windows.Forms.TextBox();
            this.tbBotFourChips = new System.Windows.Forms.TextBox();
            this.tbBotThreeChips = new System.Windows.Forms.TextBox();
            this.tbBotTwoChips = new System.Windows.Forms.TextBox();
            this.tbBotOneChips = new System.Windows.Forms.TextBox();
            this.tbPot = new System.Windows.Forms.TextBox();
            this.bOptions = new System.Windows.Forms.Button();
            this.bBigBlind = new System.Windows.Forms.Button();
            this.tbSmallBlind = new System.Windows.Forms.TextBox();
            this.bSmallBlind = new System.Windows.Forms.Button();
            this.tbBigBlind = new System.Windows.Forms.TextBox();
            this.botFiveStatus = new System.Windows.Forms.Label();
            this.botFourStatus = new System.Windows.Forms.Label();
            this.botThreeStatus = new System.Windows.Forms.Label();
            this.botOneStatus = new System.Windows.Forms.Label();
            this.playerStatus = new System.Windows.Forms.Label();
            this.botTwoStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRaise = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bFold
            // 
            this.bFold.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bFold.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bFold.Location = new System.Drawing.Point(335, 660);
            this.bFold.Name = "bFold";
            this.bFold.Size = new System.Drawing.Size(130, 62);
            this.bFold.TabIndex = 0;
            this.bFold.Text = "Fold";
            this.bFold.UseVisualStyleBackColor = true;
            this.bFold.Click += new System.EventHandler(this.bFold_Click);
            // 
            // bCheck
            // 
            this.bCheck.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCheck.Location = new System.Drawing.Point(494, 660);
            this.bCheck.Name = "bCheck";
            this.bCheck.Size = new System.Drawing.Size(134, 62);
            this.bCheck.TabIndex = 2;
            this.bCheck.Text = "Check";
            this.bCheck.UseVisualStyleBackColor = true;
            this.bCheck.Click += new System.EventHandler(this.bCheck_Click);
            // 
            // bCall
            // 
            this.bCall.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCall.Location = new System.Drawing.Point(667, 661);
            this.bCall.Name = "bCall";
            this.bCall.Size = new System.Drawing.Size(126, 62);
            this.bCall.TabIndex = 3;
            this.bCall.Text = "Call";
            this.bCall.UseVisualStyleBackColor = true;
            this.bCall.Click += new System.EventHandler(this.bCall_Click);
            // 
            // bRaise
            // 
            this.bRaise.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bRaise.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRaise.Location = new System.Drawing.Point(835, 661);
            this.bRaise.Name = "bRaise";
            this.bRaise.Size = new System.Drawing.Size(124, 62);
            this.bRaise.TabIndex = 4;
            this.bRaise.Text = "raise";
            this.bRaise.UseVisualStyleBackColor = true;
            this.bRaise.Click += new System.EventHandler(this.bRaise_Click);
            // 
            // pbTimer
            // 
            this.pbTimer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbTimer.BackColor = System.Drawing.SystemColors.Control;
            this.pbTimer.Location = new System.Drawing.Point(335, 631);
            this.pbTimer.Maximum = 1000;
            this.pbTimer.Name = "pbTimer";
            this.pbTimer.Size = new System.Drawing.Size(667, 23);
            this.pbTimer.TabIndex = 5;
            this.pbTimer.Value = 1000;
            // 
            // tbChips
            // 
            this.tbPlayerChips.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbPlayerChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPlayerChips.Location = new System.Drawing.Point(755, 553);
            this.tbPlayerChips.Name = "tbChips";
            this.tbPlayerChips.Size = new System.Drawing.Size(163, 23);
            this.tbPlayerChips.TabIndex = 6;
            this.tbPlayerChips.Text = "Chips : 0";
            // 
            // bAdd
            // 
            this.bAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bAdd.Location = new System.Drawing.Point(12, 697);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 25);
            this.bAdd.TabIndex = 7;
            this.bAdd.Text = "AddChips";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // tbAdd
            // 
            this.tbAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbAdd.Location = new System.Drawing.Point(93, 700);
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(125, 20);
            this.tbAdd.TabIndex = 8;
            // 
            // tbBotChips5
            // 
            this.tbBotFiveChips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBotFiveChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBotFiveChips.Location = new System.Drawing.Point(1012, 553);
            this.tbBotFiveChips.Name = "tbBotChips5";
            this.tbBotFiveChips.Size = new System.Drawing.Size(152, 23);
            this.tbBotFiveChips.TabIndex = 9;
            this.tbBotFiveChips.Text = "Chips : 0";
            // 
            // tbBotChips4
            // 
            this.tbBotFourChips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBotFourChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBotFourChips.Location = new System.Drawing.Point(970, 81);
            this.tbBotFourChips.Name = "tbBotChips4";
            this.tbBotFourChips.Size = new System.Drawing.Size(123, 23);
            this.tbBotFourChips.TabIndex = 10;
            this.tbBotFourChips.Text = "Chips : 0";
            // 
            // tbBotChips3
            // 
            this.tbBotThreeChips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBotThreeChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBotThreeChips.Location = new System.Drawing.Point(755, 81);
            this.tbBotThreeChips.Name = "tbBotChips3";
            this.tbBotThreeChips.Size = new System.Drawing.Size(125, 23);
            this.tbBotThreeChips.TabIndex = 11;
            this.tbBotThreeChips.Text = "Chips : 0";
            // 
            // tbBotChips2
            // 
            this.tbBotTwoChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBotTwoChips.Location = new System.Drawing.Point(276, 81);
            this.tbBotTwoChips.Name = "tbBotChips2";
            this.tbBotTwoChips.Size = new System.Drawing.Size(133, 23);
            this.tbBotTwoChips.TabIndex = 12;
            this.tbBotTwoChips.Text = "Chips : 0";
            // 
            // tbBotChips1
            // 
            this.tbBotOneChips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbBotOneChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBotOneChips.Location = new System.Drawing.Point(181, 553);
            this.tbBotOneChips.Name = "tbBotChips1";
            this.tbBotOneChips.Size = new System.Drawing.Size(142, 23);
            this.tbBotOneChips.TabIndex = 13;
            this.tbBotOneChips.Text = "Chips : 0";
            // 
            // tbPot
            // 
            this.tbPot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPot.Location = new System.Drawing.Point(606, 212);
            this.tbPot.Name = "tbPot";
            this.tbPot.Size = new System.Drawing.Size(125, 23);
            this.tbPot.TabIndex = 14;
            this.tbPot.Text = "0";
            // 
            // bOptions
            // 
            this.bOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOptions.Location = new System.Drawing.Point(12, 12);
            this.bOptions.Name = "bOptions";
            this.bOptions.Size = new System.Drawing.Size(75, 36);
            this.bOptions.TabIndex = 15;
            this.bOptions.Text = "BB/SB";
            this.bOptions.UseVisualStyleBackColor = true;
            this.bOptions.Click += new System.EventHandler(this.bOptions_Click);
            // 
            // bBB
            // 
            this.bBigBlind.Location = new System.Drawing.Point(12, 254);
            this.bBigBlind.Name = "bBB";
            this.bBigBlind.Size = new System.Drawing.Size(75, 23);
            this.bBigBlind.TabIndex = 16;
            this.bBigBlind.Text = "Big Blind";
            this.bBigBlind.UseVisualStyleBackColor = true;
            this.bBigBlind.Click += new System.EventHandler(this.bBB_Click);
            // 
            // tbSB
            // 
            this.tbSmallBlind.Location = new System.Drawing.Point(12, 228);
            this.tbSmallBlind.Name = "tbSB";
            this.tbSmallBlind.Size = new System.Drawing.Size(75, 20);
            this.tbSmallBlind.TabIndex = 17;
            this.tbSmallBlind.Text = "250";
            // 
            // bSB
            // 
            this.bSmallBlind.Location = new System.Drawing.Point(12, 199);
            this.bSmallBlind.Name = "bSB";
            this.bSmallBlind.Size = new System.Drawing.Size(75, 23);
            this.bSmallBlind.TabIndex = 18;
            this.bSmallBlind.Text = "Small Blind";
            this.bSmallBlind.UseVisualStyleBackColor = true;
            this.bSmallBlind.Click += new System.EventHandler(this.bSB_Click);
            // 
            // tbBB
            // 
            this.tbBigBlind.Location = new System.Drawing.Point(12, 283);
            this.tbBigBlind.Name = "tbBB";
            this.tbBigBlind.Size = new System.Drawing.Size(75, 20);
            this.tbBigBlind.TabIndex = 19;
            this.tbBigBlind.Text = "500";
            // 
            // b5Status
            // 
            this.botFiveStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botFiveStatus.Location = new System.Drawing.Point(1012, 579);
            this.botFiveStatus.Name = "b5Status";
            this.botFiveStatus.Size = new System.Drawing.Size(152, 32);
            this.botFiveStatus.TabIndex = 26;
            // 
            // b4Status
            // 
            this.botFourStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botFourStatus.Location = new System.Drawing.Point(970, 107);
            this.botFourStatus.Name = "b4Status";
            this.botFourStatus.Size = new System.Drawing.Size(123, 32);
            this.botFourStatus.TabIndex = 27;
            // 
            // b3Status
            // 
            this.botThreeStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botThreeStatus.Location = new System.Drawing.Point(755, 107);
            this.botThreeStatus.Name = "b3Status";
            this.botThreeStatus.Size = new System.Drawing.Size(125, 32);
            this.botThreeStatus.TabIndex = 28;
            // 
            // b1Status
            // 
            this.botOneStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.botOneStatus.Location = new System.Drawing.Point(181, 579);
            this.botOneStatus.Name = "b1Status";
            this.botOneStatus.Size = new System.Drawing.Size(142, 32);
            this.botOneStatus.TabIndex = 29;
            // 
            // pStatus
            // 
            this.playerStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playerStatus.Location = new System.Drawing.Point(755, 579);
            this.playerStatus.Name = "pStatus";
            this.playerStatus.Size = new System.Drawing.Size(163, 32);
            this.playerStatus.TabIndex = 30;
            // 
            // b2Status
            // 
            this.botTwoStatus.Location = new System.Drawing.Point(276, 107);
            this.botTwoStatus.Name = "b2Status";
            this.botTwoStatus.Size = new System.Drawing.Size(133, 32);
            this.botTwoStatus.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(654, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pot";
            // 
            // tbRaise
            // 
            this.tbRaise.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbRaise.Location = new System.Drawing.Point(965, 703);
            this.tbRaise.Name = "tbRaise";
            this.tbRaise.Size = new System.Drawing.Size(108, 20);
            this.tbRaise.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Poker.Properties.Resources.poker_table___Copy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.tbRaise);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botTwoStatus);
            this.Controls.Add(this.playerStatus);
            this.Controls.Add(this.botOneStatus);
            this.Controls.Add(this.botThreeStatus);
            this.Controls.Add(this.botFourStatus);
            this.Controls.Add(this.botFiveStatus);
            this.Controls.Add(this.tbBigBlind);
            this.Controls.Add(this.bSmallBlind);
            this.Controls.Add(this.tbSmallBlind);
            this.Controls.Add(this.bBigBlind);
            this.Controls.Add(this.bOptions);
            this.Controls.Add(this.tbPot);
            this.Controls.Add(this.tbBotOneChips);
            this.Controls.Add(this.tbBotTwoChips);
            this.Controls.Add(this.tbBotThreeChips);
            this.Controls.Add(this.tbBotFourChips);
            this.Controls.Add(this.tbBotFiveChips);
            this.Controls.Add(this.tbAdd);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.tbPlayerChips);
            this.Controls.Add(this.pbTimer);
            this.Controls.Add(this.bRaise);
            this.Controls.Add(this.bCall);
            this.Controls.Add(this.bCheck);
            this.Controls.Add(this.bFold);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "GLS Texas Poker";
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Layout_Change);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bFold;
        private System.Windows.Forms.Button bCheck;
        private System.Windows.Forms.Button bCall;
        private System.Windows.Forms.Button bRaise;
        private System.Windows.Forms.ProgressBar pbTimer;
        private System.Windows.Forms.TextBox tbPlayerChips;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.TextBox tbAdd;
        private System.Windows.Forms.TextBox tbBotFiveChips;
        private System.Windows.Forms.TextBox tbBotFourChips;
        private System.Windows.Forms.TextBox tbBotThreeChips;
        private System.Windows.Forms.TextBox tbBotTwoChips;
        private System.Windows.Forms.TextBox tbBotOneChips;
        private System.Windows.Forms.TextBox tbPot;
        private System.Windows.Forms.Button bOptions;
        private System.Windows.Forms.Button bBigBlind;
        private System.Windows.Forms.TextBox tbSmallBlind;
        private System.Windows.Forms.Button bSmallBlind;
        private System.Windows.Forms.TextBox tbBigBlind;
        private System.Windows.Forms.Label botFiveStatus;
        private System.Windows.Forms.Label botFourStatus;
        private System.Windows.Forms.Label botThreeStatus;
        private System.Windows.Forms.Label botOneStatus;
        private System.Windows.Forms.Label playerStatus;
        private System.Windows.Forms.Label botTwoStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRaise;



    }
}

