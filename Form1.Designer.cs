﻿namespace AdonaiSoft_Utilitario
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.comandosql = new System.Windows.Forms.RichTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.baseOriginal = new MetroFramework.Controls.MetroTextBox();
            this.LocalDestino = new MetroFramework.Controls.MetroTextBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.txtClasse = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.txtPakage = new MetroFramework.Controls.MetroTextBox();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.txtDataBase = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtTabela = new MetroFramework.Controls.MetroTextBox();
            this.cheResource = new MetroFramework.Controls.MetroCheckBox();
            this.cheController = new MetroFramework.Controls.MetroCheckBox();
            this.cheModel = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cmbBanco = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtUser = new MetroFramework.Controls.MetroTextBox();
            this.txtLocalBanco = new MetroFramework.Controls.MetroTextBox();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Location = new System.Drawing.Point(8, 63);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(754, 411);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.metroButton2);
            this.metroTabPage1.Controls.Add(this.metroButton1);
            this.metroTabPage1.Controls.Add(this.metroLabel3);
            this.metroTabPage1.Controls.Add(this.comandosql);
            this.metroTabPage1.Controls.Add(this.metroLabel2);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.Controls.Add(this.baseOriginal);
            this.metroTabPage1.Controls.Add(this.LocalDestino);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(746, 369);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Banco de Dados";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(644, 83);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(94, 23);
            this.metroButton2.TabIndex = 9;
            this.metroButton2.Text = "Atualizar";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(253, 83);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(94, 23);
            this.metroButton1.TabIndex = 8;
            this.metroButton1.Text = "Atualizar";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(4, 115);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(33, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "SQL";
            // 
            // comandosql
            // 
            this.comandosql.Location = new System.Drawing.Point(4, 137);
            this.comandosql.Name = "comandosql";
            this.comandosql.Size = new System.Drawing.Size(739, 229);
            this.comandosql.TabIndex = 6;
            this.comandosql.Text = "";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(390, 32);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(137, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Nome Banco Original";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 32);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(79, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Local Banco";
            // 
            // baseOriginal
            // 
            // 
            // 
            // 
            this.baseOriginal.CustomButton.Image = null;
            this.baseOriginal.CustomButton.Location = new System.Drawing.Point(326, 1);
            this.baseOriginal.CustomButton.Name = "";
            this.baseOriginal.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.baseOriginal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.baseOriginal.CustomButton.TabIndex = 1;
            this.baseOriginal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.baseOriginal.CustomButton.UseSelectable = true;
            this.baseOriginal.CustomButton.Visible = false;
            this.baseOriginal.Lines = new string[0];
            this.baseOriginal.Location = new System.Drawing.Point(390, 54);
            this.baseOriginal.MaxLength = 32767;
            this.baseOriginal.Name = "baseOriginal";
            this.baseOriginal.PasswordChar = '\0';
            this.baseOriginal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.baseOriginal.SelectedText = "";
            this.baseOriginal.SelectionLength = 0;
            this.baseOriginal.SelectionStart = 0;
            this.baseOriginal.ShortcutsEnabled = true;
            this.baseOriginal.Size = new System.Drawing.Size(348, 23);
            this.baseOriginal.TabIndex = 3;
            this.baseOriginal.UseSelectable = true;
            this.baseOriginal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.baseOriginal.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LocalDestino
            // 
            // 
            // 
            // 
            this.LocalDestino.CustomButton.Image = null;
            this.LocalDestino.CustomButton.Location = new System.Drawing.Point(322, 1);
            this.LocalDestino.CustomButton.Name = "";
            this.LocalDestino.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.LocalDestino.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.LocalDestino.CustomButton.TabIndex = 1;
            this.LocalDestino.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LocalDestino.CustomButton.UseSelectable = true;
            this.LocalDestino.CustomButton.Visible = false;
            this.LocalDestino.Lines = new string[0];
            this.LocalDestino.Location = new System.Drawing.Point(3, 54);
            this.LocalDestino.MaxLength = 32767;
            this.LocalDestino.Name = "LocalDestino";
            this.LocalDestino.PasswordChar = '\0';
            this.LocalDestino.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.LocalDestino.SelectedText = "";
            this.LocalDestino.SelectionLength = 0;
            this.LocalDestino.SelectionStart = 0;
            this.LocalDestino.ShortcutsEnabled = true;
            this.LocalDestino.Size = new System.Drawing.Size(344, 23);
            this.LocalDestino.TabIndex = 2;
            this.LocalDestino.UseSelectable = true;
            this.LocalDestino.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.LocalDestino.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroLabel11);
            this.metroTabPage2.Controls.Add(this.txtClasse);
            this.metroTabPage2.Controls.Add(this.metroLabel10);
            this.metroTabPage2.Controls.Add(this.txtPakage);
            this.metroTabPage2.Controls.Add(this.metroButton3);
            this.metroTabPage2.Controls.Add(this.metroLabel9);
            this.metroTabPage2.Controls.Add(this.txtDataBase);
            this.metroTabPage2.Controls.Add(this.metroLabel8);
            this.metroTabPage2.Controls.Add(this.txtTabela);
            this.metroTabPage2.Controls.Add(this.cheResource);
            this.metroTabPage2.Controls.Add(this.cheController);
            this.metroTabPage2.Controls.Add(this.cheModel);
            this.metroTabPage2.Controls.Add(this.metroLabel7);
            this.metroTabPage2.Controls.Add(this.txtPassword);
            this.metroTabPage2.Controls.Add(this.metroLabel6);
            this.metroTabPage2.Controls.Add(this.metroLabel5);
            this.metroTabPage2.Controls.Add(this.cmbBanco);
            this.metroTabPage2.Controls.Add(this.metroLabel4);
            this.metroTabPage2.Controls.Add(this.txtUser);
            this.metroTabPage2.Controls.Add(this.txtLocalBanco);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(746, 369);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Codigo Java";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(421, 174);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(45, 19);
            this.metroLabel11.TabIndex = 22;
            this.metroLabel11.Text = "Classe";
            // 
            // txtClasse
            // 
            // 
            // 
            // 
            this.txtClasse.CustomButton.Image = null;
            this.txtClasse.CustomButton.Location = new System.Drawing.Point(273, 1);
            this.txtClasse.CustomButton.Name = "";
            this.txtClasse.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtClasse.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtClasse.CustomButton.TabIndex = 1;
            this.txtClasse.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtClasse.CustomButton.UseSelectable = true;
            this.txtClasse.CustomButton.Visible = false;
            this.txtClasse.Lines = new string[] {
        "PessoaMembro"};
            this.txtClasse.Location = new System.Drawing.Point(421, 196);
            this.txtClasse.MaxLength = 32767;
            this.txtClasse.Name = "txtClasse";
            this.txtClasse.PasswordChar = '\0';
            this.txtClasse.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtClasse.SelectedText = "";
            this.txtClasse.SelectionLength = 0;
            this.txtClasse.SelectionStart = 0;
            this.txtClasse.ShortcutsEnabled = true;
            this.txtClasse.Size = new System.Drawing.Size(295, 23);
            this.txtClasse.TabIndex = 21;
            this.txtClasse.Text = "PessoaMembro";
            this.txtClasse.UseSelectable = true;
            this.txtClasse.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtClasse.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtClasse.Click += new System.EventHandler(this.metroTextBox2_Click);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(421, 116);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(57, 19);
            this.metroLabel10.TabIndex = 20;
            this.metroLabel10.Text = "Package";
            // 
            // txtPakage
            // 
            // 
            // 
            // 
            this.txtPakage.CustomButton.Image = null;
            this.txtPakage.CustomButton.Location = new System.Drawing.Point(273, 1);
            this.txtPakage.CustomButton.Name = "";
            this.txtPakage.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPakage.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPakage.CustomButton.TabIndex = 1;
            this.txtPakage.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPakage.CustomButton.UseSelectable = true;
            this.txtPakage.CustomButton.Visible = false;
            this.txtPakage.Lines = new string[] {
        "com.adonaisoft"};
            this.txtPakage.Location = new System.Drawing.Point(421, 138);
            this.txtPakage.MaxLength = 32767;
            this.txtPakage.Name = "txtPakage";
            this.txtPakage.PasswordChar = '\0';
            this.txtPakage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPakage.SelectedText = "";
            this.txtPakage.SelectionLength = 0;
            this.txtPakage.SelectionStart = 0;
            this.txtPakage.ShortcutsEnabled = true;
            this.txtPakage.Size = new System.Drawing.Size(295, 23);
            this.txtPakage.TabIndex = 19;
            this.txtPakage.Text = "com.adonaisoft";
            this.txtPakage.UseSelectable = true;
            this.txtPakage.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPakage.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(594, 318);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(122, 29);
            this.metroButton3.TabIndex = 18;
            this.metroButton3.Text = "Gerar";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(421, 65);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(104, 19);
            this.metroLabel9.TabIndex = 17;
            this.metroLabel9.Text = "Nome DataBase";
            // 
            // txtDataBase
            // 
            // 
            // 
            // 
            this.txtDataBase.CustomButton.Image = null;
            this.txtDataBase.CustomButton.Location = new System.Drawing.Point(273, 1);
            this.txtDataBase.CustomButton.Name = "";
            this.txtDataBase.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtDataBase.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDataBase.CustomButton.TabIndex = 1;
            this.txtDataBase.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDataBase.CustomButton.UseSelectable = true;
            this.txtDataBase.CustomButton.Visible = false;
            this.txtDataBase.Lines = new string[] {
        "adonai"};
            this.txtDataBase.Location = new System.Drawing.Point(421, 87);
            this.txtDataBase.MaxLength = 32767;
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.PasswordChar = '\0';
            this.txtDataBase.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDataBase.SelectedText = "";
            this.txtDataBase.SelectionLength = 0;
            this.txtDataBase.SelectionStart = 0;
            this.txtDataBase.ShortcutsEnabled = true;
            this.txtDataBase.Size = new System.Drawing.Size(295, 23);
            this.txtDataBase.TabIndex = 16;
            this.txtDataBase.Text = "adonai";
            this.txtDataBase.UseSelectable = true;
            this.txtDataBase.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDataBase.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtDataBase.Click += new System.EventHandler(this.txtDataBase_Click);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(3, 221);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(87, 19);
            this.metroLabel8.TabIndex = 15;
            this.metroLabel8.Text = "Nome Tabela";
            // 
            // txtTabela
            // 
            // 
            // 
            // 
            this.txtTabela.CustomButton.Image = null;
            this.txtTabela.CustomButton.Location = new System.Drawing.Point(280, 1);
            this.txtTabela.CustomButton.Name = "";
            this.txtTabela.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTabela.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTabela.CustomButton.TabIndex = 1;
            this.txtTabela.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTabela.CustomButton.UseSelectable = true;
            this.txtTabela.CustomButton.Visible = false;
            this.txtTabela.Lines = new string[] {
        "pessoa_membro"};
            this.txtTabela.Location = new System.Drawing.Point(3, 243);
            this.txtTabela.MaxLength = 32767;
            this.txtTabela.Name = "txtTabela";
            this.txtTabela.PasswordChar = '\0';
            this.txtTabela.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTabela.SelectedText = "";
            this.txtTabela.SelectionLength = 0;
            this.txtTabela.SelectionStart = 0;
            this.txtTabela.ShortcutsEnabled = true;
            this.txtTabela.Size = new System.Drawing.Size(302, 23);
            this.txtTabela.TabIndex = 14;
            this.txtTabela.Text = "pessoa_membro";
            this.txtTabela.UseSelectable = true;
            this.txtTabela.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTabela.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cheResource
            // 
            this.cheResource.AutoSize = true;
            this.cheResource.Location = new System.Drawing.Point(234, 293);
            this.cheResource.Name = "cheResource";
            this.cheResource.Size = new System.Drawing.Size(71, 15);
            this.cheResource.TabIndex = 13;
            this.cheResource.Text = "Resource";
            this.cheResource.UseSelectable = true;
            // 
            // cheController
            // 
            this.cheController.AutoSize = true;
            this.cheController.Location = new System.Drawing.Point(109, 293);
            this.cheController.Name = "cheController";
            this.cheController.Size = new System.Drawing.Size(76, 15);
            this.cheController.TabIndex = 12;
            this.cheController.Text = "Controller";
            this.cheController.UseSelectable = true;
            // 
            // cheModel
            // 
            this.cheModel.AutoSize = true;
            this.cheModel.Location = new System.Drawing.Point(3, 293);
            this.cheModel.Name = "cheModel";
            this.cheModel.Size = new System.Drawing.Size(57, 15);
            this.cheModel.TabIndex = 11;
            this.cheModel.Text = "Model";
            this.cheModel.UseSelectable = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(3, 116);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(63, 19);
            this.metroLabel7.TabIndex = 10;
            this.metroLabel7.Text = "Password";
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(280, 1);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.Lines = new string[] {
        "1816"};
            this.txtPassword.Location = new System.Drawing.Point(3, 138);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(302, 23);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.Text = "1816";
            this.txtPassword.UseSelectable = true;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(3, 61);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(35, 19);
            this.metroLabel6.TabIndex = 8;
            this.metroLabel6.Text = "User";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(421, 11);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(45, 19);
            this.metroLabel5.TabIndex = 7;
            this.metroLabel5.Text = "Banco";
            // 
            // cmbBanco
            // 
            this.cmbBanco.FormattingEnabled = true;
            this.cmbBanco.ItemHeight = 23;
            this.cmbBanco.Items.AddRange(new object[] {
            "PostgreSql",
            "SQL Server",
            "MySql"});
            this.cmbBanco.Location = new System.Drawing.Point(421, 33);
            this.cmbBanco.Name = "cmbBanco";
            this.cmbBanco.Size = new System.Drawing.Size(295, 29);
            this.cmbBanco.TabIndex = 6;
            this.cmbBanco.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(3, 11);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(79, 19);
            this.metroLabel4.TabIndex = 5;
            this.metroLabel4.Text = "Local Banco";
            // 
            // txtUser
            // 
            // 
            // 
            // 
            this.txtUser.CustomButton.Image = null;
            this.txtUser.CustomButton.Location = new System.Drawing.Point(280, 1);
            this.txtUser.CustomButton.Name = "";
            this.txtUser.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUser.CustomButton.TabIndex = 1;
            this.txtUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUser.CustomButton.UseSelectable = true;
            this.txtUser.CustomButton.Visible = false;
            this.txtUser.Lines = new string[] {
        "postgres"};
            this.txtUser.Location = new System.Drawing.Point(3, 83);
            this.txtUser.MaxLength = 32767;
            this.txtUser.Name = "txtUser";
            this.txtUser.PasswordChar = '\0';
            this.txtUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUser.SelectedText = "";
            this.txtUser.SelectionLength = 0;
            this.txtUser.SelectionStart = 0;
            this.txtUser.ShortcutsEnabled = true;
            this.txtUser.Size = new System.Drawing.Size(302, 23);
            this.txtUser.TabIndex = 3;
            this.txtUser.Text = "postgres";
            this.txtUser.UseSelectable = true;
            this.txtUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtLocalBanco
            // 
            // 
            // 
            // 
            this.txtLocalBanco.CustomButton.Image = null;
            this.txtLocalBanco.CustomButton.Location = new System.Drawing.Point(280, 1);
            this.txtLocalBanco.CustomButton.Name = "";
            this.txtLocalBanco.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtLocalBanco.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLocalBanco.CustomButton.TabIndex = 1;
            this.txtLocalBanco.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLocalBanco.CustomButton.UseSelectable = true;
            this.txtLocalBanco.CustomButton.Visible = false;
            this.txtLocalBanco.Lines = new string[] {
        "localhost"};
            this.txtLocalBanco.Location = new System.Drawing.Point(3, 33);
            this.txtLocalBanco.MaxLength = 32767;
            this.txtLocalBanco.Name = "txtLocalBanco";
            this.txtLocalBanco.PasswordChar = '\0';
            this.txtLocalBanco.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLocalBanco.SelectedText = "";
            this.txtLocalBanco.SelectionLength = 0;
            this.txtLocalBanco.SelectionStart = 0;
            this.txtLocalBanco.ShortcutsEnabled = true;
            this.txtLocalBanco.Size = new System.Drawing.Size(302, 23);
            this.txtLocalBanco.TabIndex = 2;
            this.txtLocalBanco.Text = "localhost";
            this.txtLocalBanco.UseSelectable = true;
            this.txtLocalBanco.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLocalBanco.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(746, 369);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Json to Java";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 497);
            this.Controls.Add(this.metroTabControl1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "AdonaiSoft Util";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.RichTextBox comandosql;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox baseOriginal;
        private MetroFramework.Controls.MetroTextBox LocalDestino;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox txtDataBase;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtTabela;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cmbBanco;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtUser;
        private MetroFramework.Controls.MetroTextBox txtLocalBanco;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroCheckBox cheResource;
        private MetroFramework.Controls.MetroCheckBox cheController;
        private MetroFramework.Controls.MetroCheckBox cheModel;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTextBox txtClasse;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox txtPakage;
    }
}

