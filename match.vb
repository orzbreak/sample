Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Text

' Open eVision Namespace
Imports Euresys.Open_eVision_2_6

Namespace MchMatch
    ''' <summary>
    ''' Summary description for Form1.
    ''' </summary>
    Public Class MainForm
        Inherits System.Windows.Forms.Form



        ' Open eVision objects declaration
        Private m_Source As New EImageBW8()
        Private m_ROI As New EROIBW8()
        Private m_Matcher As New EMatcher()
        Private m_Handle As EDragHandle

        Private m_bFirstLoad As Boolean = True

        Private openFileDialog As System.Windows.Forms.OpenFileDialog
        Private mainMenu As System.Windows.Forms.MainMenu
        Private menuItem1 As System.Windows.Forms.MenuItem
        Private menuItem2 As System.Windows.Forms.MenuItem
        Private File As System.Windows.Forms.MenuItem
        Private WithEvents FileOpen As System.Windows.Forms.MenuItem
        Private WithEvents FileExit As System.Windows.Forms.MenuItem
        Private WithEvents Learn As System.Windows.Forms.MenuItem
        Private WithEvents Tolerances As System.Windows.Forms.MenuItem
        Private WithEvents TolerancesAngle0 As System.Windows.Forms.MenuItem
        Private WithEvents TolerancesAngle5 As System.Windows.Forms.MenuItem
        Private WithEvents TolerancesAngle10 As System.Windows.Forms.MenuItem
        Private WithEvents TolerancesAngle90 As System.Windows.Forms.MenuItem
        Private WithEvents TolerancesAngle180 As System.Windows.Forms.MenuItem
        Private WithEvents TolerancesScaling0 As System.Windows.Forms.MenuItem
        Private WithEvents TolerancesScaling5 As System.Windows.Forms.MenuItem
        Private WithEvents TolerancesScaling10 As System.Windows.Forms.MenuItem
        Private WithEvents TolerancesScaling25 As System.Windows.Forms.MenuItem
        Private WithEvents TolerancesScaling50 As System.Windows.Forms.MenuItem
        Private WithEvents matchMenu As System.Windows.Forms.MenuItem
        Private menuItem3 As System.Windows.Forms.MenuItem
        Private WithEvents ApplicationIntroduction As System.Windows.Forms.MenuItem
        Dim Pic_times As Integer = 2

        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()

            '
            ' TODO: Add any constructor code after InitializeComponent call
            '

            ' Welcome message box
            ApplicationIntroduction_Click(Nothing, Nothing)
        End Sub

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
            Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
            Me.mainMenu = New System.Windows.Forms.MainMenu(Me.components)
            Me.File = New System.Windows.Forms.MenuItem()
            Me.FileOpen = New System.Windows.Forms.MenuItem()
            Me.menuItem1 = New System.Windows.Forms.MenuItem()
            Me.FileExit = New System.Windows.Forms.MenuItem()
            Me.Learn = New System.Windows.Forms.MenuItem()
            Me.Tolerances = New System.Windows.Forms.MenuItem()
            Me.TolerancesAngle0 = New System.Windows.Forms.MenuItem()
            Me.TolerancesAngle5 = New System.Windows.Forms.MenuItem()
            Me.TolerancesAngle10 = New System.Windows.Forms.MenuItem()
            Me.TolerancesAngle90 = New System.Windows.Forms.MenuItem()
            Me.TolerancesAngle180 = New System.Windows.Forms.MenuItem()
            Me.menuItem2 = New System.Windows.Forms.MenuItem()
            Me.TolerancesScaling0 = New System.Windows.Forms.MenuItem()
            Me.TolerancesScaling5 = New System.Windows.Forms.MenuItem()
            Me.TolerancesScaling10 = New System.Windows.Forms.MenuItem()
            Me.TolerancesScaling25 = New System.Windows.Forms.MenuItem()
            Me.TolerancesScaling50 = New System.Windows.Forms.MenuItem()
            Me.matchMenu = New System.Windows.Forms.MenuItem()
            Me.menuItem3 = New System.Windows.Forms.MenuItem()
            Me.ApplicationIntroduction = New System.Windows.Forms.MenuItem()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Button4 = New System.Windows.Forms.Button()
            Me.PictureBox2 = New System.Windows.Forms.PictureBox()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.PictureBox3 = New System.Windows.Forms.PictureBox()
            Me.Pic_check = New System.Windows.Forms.PictureBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.PictureBox4 = New System.Windows.Forms.PictureBox()
            Me.Button5 = New System.Windows.Forms.Button()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.Button6 = New System.Windows.Forms.Button()
            Me.statusBar = New System.Windows.Forms.StatusBar()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Pic_check, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'mainMenu
            '
            Me.mainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.File, Me.Learn, Me.Tolerances, Me.matchMenu, Me.menuItem3})
            '
            'File
            '
            Me.File.Index = 0
            Me.File.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FileOpen, Me.menuItem1, Me.FileExit})
            Me.File.Text = "File"
            '
            'FileOpen
            '
            Me.FileOpen.Index = 0
            Me.FileOpen.Text = "Open..."
            '
            'menuItem1
            '
            Me.menuItem1.Index = 1
            Me.menuItem1.Text = "-"
            '
            'FileExit
            '
            Me.FileExit.Index = 2
            Me.FileExit.Text = "Exit"
            '
            'Learn
            '
            Me.Learn.Index = 1
            Me.Learn.Text = "Learn"
            '
            'Tolerances
            '
            Me.Tolerances.Index = 2
            Me.Tolerances.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.TolerancesAngle0, Me.TolerancesAngle5, Me.TolerancesAngle10, Me.TolerancesAngle90, Me.TolerancesAngle180, Me.menuItem2, Me.TolerancesScaling0, Me.TolerancesScaling5, Me.TolerancesScaling10, Me.TolerancesScaling25, Me.TolerancesScaling50})
            Me.Tolerances.Text = "Tolerances"
            '
            'TolerancesAngle0
            '
            Me.TolerancesAngle0.Checked = True
            Me.TolerancesAngle0.Index = 0
            Me.TolerancesAngle0.Text = "No Rotation"
            '
            'TolerancesAngle5
            '
            Me.TolerancesAngle5.Index = 1
            Me.TolerancesAngle5.Text = "+/- 5?"
            '
            'TolerancesAngle10
            '
            Me.TolerancesAngle10.Index = 2
            Me.TolerancesAngle10.Text = "+/- 10?"
            '
            'TolerancesAngle90
            '
            Me.TolerancesAngle90.Index = 3
            Me.TolerancesAngle90.Text = "Half Turn"
            '
            'TolerancesAngle180
            '
            Me.TolerancesAngle180.Index = 4
            Me.TolerancesAngle180.Text = "Full Turn"
            '
            'menuItem2
            '
            Me.menuItem2.Index = 5
            Me.menuItem2.Text = "-"
            '
            'TolerancesScaling0
            '
            Me.TolerancesScaling0.Checked = True
            Me.TolerancesScaling0.Index = 6
            Me.TolerancesScaling0.Text = "No Scaling"
            '
            'TolerancesScaling5
            '
            Me.TolerancesScaling5.Index = 7
            Me.TolerancesScaling5.Text = "+/- 5%"
            '
            'TolerancesScaling10
            '
            Me.TolerancesScaling10.Index = 8
            Me.TolerancesScaling10.Text = "+/- 10%"
            '
            'TolerancesScaling25
            '
            Me.TolerancesScaling25.Index = 9
            Me.TolerancesScaling25.Text = "+/- 25%"
            '
            'TolerancesScaling50
            '
            Me.TolerancesScaling50.Index = 10
            Me.TolerancesScaling50.Text = "+/- 50%"
            '
            'matchMenu
            '
            Me.matchMenu.Index = 3
            Me.matchMenu.Text = "Match"
            '
            'menuItem3
            '
            Me.menuItem3.Index = 4
            Me.menuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ApplicationIntroduction})
            Me.menuItem3.Text = "Help"
            '
            'ApplicationIntroduction
            '
            Me.ApplicationIntroduction.Index = 0
            Me.ApplicationIntroduction.Text = "Application Introduction..."
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(1181, 365)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(75, 23)
            Me.Button1.TabIndex = 1
            Me.Button1.Text = "Diepad Match"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'PictureBox1
            '
            Me.PictureBox1.Location = New System.Drawing.Point(1181, 159)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(236, 142)
            Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.PictureBox1.TabIndex = 3
            Me.PictureBox1.TabStop = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(706, 107)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(9, 12)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "-"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(706, 135)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(9, 12)
            Me.Label2.TabIndex = 7
            Me.Label2.Text = "-"
            '
            'Button4
            '
            Me.Button4.Location = New System.Drawing.Point(1181, 336)
            Me.Button4.Name = "Button4"
            Me.Button4.Size = New System.Drawing.Size(75, 23)
            Me.Button4.TabIndex = 8
            Me.Button4.Text = "Bear Match"
            Me.Button4.UseVisualStyleBackColor = True
            '
            'PictureBox2
            '
            Me.PictureBox2.Location = New System.Drawing.Point(1181, 11)
            Me.PictureBox2.Name = "PictureBox2"
            Me.PictureBox2.Size = New System.Drawing.Size(236, 142)
            Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.PictureBox2.TabIndex = 9
            Me.PictureBox2.TabStop = False
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(1271, 307)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(75, 23)
            Me.Button2.TabIndex = 10
            Me.Button2.Text = "開始檢測"
            Me.Button2.UseVisualStyleBackColor = True
            '
            'Button3
            '
            Me.Button3.Location = New System.Drawing.Point(1181, 307)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(75, 23)
            Me.Button3.TabIndex = 11
            Me.Button3.Text = "連續量測"
            Me.Button3.UseVisualStyleBackColor = True
            '
            'Timer1
            '
            Me.Timer1.Interval = 300
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(638, 107)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(52, 12)
            Me.Label3.TabIndex = 12
            Me.Label3.Text = "X座標:    "
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(638, 135)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(52, 12)
            Me.Label4.TabIndex = 13
            Me.Label4.Text = "Y座標:    "
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(706, 82)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(9, 12)
            Me.Label5.TabIndex = 14
            Me.Label5.Text = "-"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(638, 82)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(41, 12)
            Me.Label6.TabIndex = 15
            Me.Label6.Text = "角度:   "
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(638, 55)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(49, 12)
            Me.Label7.TabIndex = 16
            Me.Label7.Text = "Match:    "
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(706, 55)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(9, 12)
            Me.Label8.TabIndex = 17
            Me.Label8.Text = "-"
            '
            'PictureBox3
            '
            Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
            Me.PictureBox3.Location = New System.Drawing.Point(598, 12)
            Me.PictureBox3.Name = "PictureBox3"
            Me.PictureBox3.Size = New System.Drawing.Size(235, 222)
            Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.PictureBox3.TabIndex = 18
            Me.PictureBox3.TabStop = False
            '
            'Pic_check
            '
            Me.Pic_check.Location = New System.Drawing.Point(638, 367)
            Me.Pic_check.Name = "Pic_check"
            Me.Pic_check.Size = New System.Drawing.Size(100, 50)
            Me.Pic_check.TabIndex = 19
            Me.Pic_check.TabStop = False
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(638, 261)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(68, 12)
            Me.Label10.TabIndex = 28
            Me.Label10.Text = "檢測數目:    "
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(706, 288)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(11, 12)
            Me.Label11.TabIndex = 26
            Me.Label11.Text = "0"
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(706, 261)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(11, 12)
            Me.Label12.TabIndex = 29
            Me.Label12.Text = "0"
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(638, 313)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(60, 12)
            Me.Label13.TabIndex = 24
            Me.Label13.Text = "NG數目:    "
            '
            'Label14
            '
            Me.Label14.AutoSize = True
            Me.Label14.Location = New System.Drawing.Point(706, 313)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(11, 12)
            Me.Label14.TabIndex = 22
            Me.Label14.Text = "0"
            '
            'Label15
            '
            Me.Label15.AutoSize = True
            Me.Label15.Location = New System.Drawing.Point(638, 288)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(57, 12)
            Me.Label15.TabIndex = 27
            Me.Label15.Text = "OK數目:   "
            '
            'PictureBox4
            '
            Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
            Me.PictureBox4.Location = New System.Drawing.Point(598, 240)
            Me.PictureBox4.Name = "PictureBox4"
            Me.PictureBox4.Size = New System.Drawing.Size(235, 222)
            Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.PictureBox4.TabIndex = 30
            Me.PictureBox4.TabStop = False
            '
            'Button5
            '
            Me.Button5.Location = New System.Drawing.Point(1181, 394)
            Me.Button5.Name = "Button5"
            Me.Button5.Size = New System.Drawing.Size(75, 23)
            Me.Button5.TabIndex = 31
            Me.Button5.Text = "Frame Match"
            Me.Button5.UseVisualStyleBackColor = True
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(639, 29)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(68, 12)
            Me.Label9.TabIndex = 32
            Me.Label9.Text = "產品名稱:    "
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Location = New System.Drawing.Point(707, 29)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(9, 12)
            Me.Label16.TabIndex = 33
            Me.Label16.Text = "-"
            '
            'Button6
            '
            Me.Button6.Location = New System.Drawing.Point(640, 166)
            Me.Button6.Name = "Button6"
            Me.Button6.Size = New System.Drawing.Size(77, 37)
            Me.Button6.TabIndex = 34
            Me.Button6.Text = "開始檢測"
            Me.Button6.UseVisualStyleBackColor = True
            '
            'statusBar
            '
            Me.statusBar.Location = New System.Drawing.Point(0, 527)
            Me.statusBar.Name = "statusBar"
            Me.statusBar.Size = New System.Drawing.Size(850, 27)
            Me.statusBar.TabIndex = 0
            '
            'MainForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
            Me.ClientSize = New System.Drawing.Size(850, 554)
            Me.Controls.Add(Me.Button6)
            Me.Controls.Add(Me.Label9)
            Me.Controls.Add(Me.Label16)
            Me.Controls.Add(Me.Button5)
            Me.Controls.Add(Me.Label10)
            Me.Controls.Add(Me.Label11)
            Me.Controls.Add(Me.Label12)
            Me.Controls.Add(Me.Label13)
            Me.Controls.Add(Me.Label14)
            Me.Controls.Add(Me.Label15)
            Me.Controls.Add(Me.PictureBox2)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.Pic_check)
            Me.Controls.Add(Me.statusBar)
            Me.Controls.Add(Me.Button2)
            Me.Controls.Add(Me.Button4)
            Me.Controls.Add(Me.Button3)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.Label7)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.Label8)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.PictureBox3)
            Me.Controls.Add(Me.PictureBox4)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Menu = Me.mainMenu
            Me.Name = "MainForm"
            Me.Text = "MchMatch"
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Pic_check, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
#End Region

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread()>
        Private Shared Sub Main()
            Application.Run(New MainForm())
        End Sub


        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Attach the ROI to the image
            m_ROI.Attach(m_Source)

            ' Set angle and scaling tolerances to none
            m_Matcher.MinAngle = 0
            m_Matcher.MaxAngle = 0
            m_Matcher.MinScale = 1
            m_Matcher.MaxScale = 1

        End Sub


        Private Sub FileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileOpen.Click

            ' Show open file dialog
            openFileDialog.Filter = "Image Files (*.tif;*.jpg;*.bmp)|*.tif;*.jpg;*.bmp"
            If openFileDialog.ShowDialog() = DialogResult.Cancel Then
                ' No image selected, exit
                Return
            End If

            Try
                ' Load the image
                m_Source.Load(openFileDialog.FileName)

                If m_bFirstLoad Then
                    ' Set the ROI position on the image
                    m_ROI.SetPlacement(m_Source.Width / 4, m_Source.Height / 4, m_Source.Width / 2, m_Source.Width / 2)

                    m_bFirstLoad = False
                End If

                ' Has the learning already been done?
                If m_Matcher.PatternLearnt Then
                    ' Match the pattern
                    m_Matcher.Match(m_Source)

                End If
            Catch exc As EException
                MessageBox.Show(exc.Message)
            End Try

            ' Refresh the form
            Refresh()
        End Sub

        Private Sub MainForm_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
            ' Redraw form content
            Redraw(e.Graphics)
        End Sub

        Private Sub Redraw(ByVal g As Graphics)
            If m_Source.IsVoid Then
                Return
            End If

            ' Draw the image
            m_Source.Draw(g)

            ' Draw the ROI frame
            m_ROI.DrawFrame(g, True)

            ' Draw found instances of the pattern
            Dim greenPen As New ERGBColor(0, 255, 0)
            m_Matcher.DrawPositions(g, greenPen, True)

        End Sub

        Private Sub MainForm_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
            ' If Left mouse button is down
            If e.Button = MouseButtons.Left Then
                ' Get ROI handle under cursor
                m_Handle = m_ROI.HitTest(e.X, e.Y)
            End If
        End Sub

        Private Sub MainForm_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
            ' If there is a handle under the cursor
            If m_Handle <> EDragHandle.NoHandle Then
                ' Drag ROI handle to cursor position
                m_ROI.Drag(m_Handle, e.X, e.Y)

                ' Redraw form content
                Redraw(CreateGraphics())
            End If
        End Sub

        Private Sub MainForm_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
            ' Reset current handle to none
            m_Handle = EDragHandle.NoHandle
        End Sub

        Private Sub FileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileExit.Click
            ' Close form and exit
            Close()
        End Sub

        Private Sub Learn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Learn.Click

            Try
                ' Learn the pattern defined by the ROI
                m_Matcher.LearnPattern(m_ROI)

                ' If a pattern has been learnt
                If m_Matcher.PatternLearnt Then
                    ' Find the pattern in the Image
                    m_Matcher.Match(m_Source)
                End If

            Catch exc As EException
                MessageBox.Show(exc.Message)
            End Try

            ' Redraw the form content
            Redraw(CreateGraphics())

        End Sub

        Private Sub matchMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles matchMenu.Click

            Try
                ' If a pattern has been learnt
                If m_Matcher.PatternLearnt Then

                    ' Find the pattern in the Image
                    m_Matcher.Match(m_Source)
                End If

            Catch exc As EException
                MessageBox.Show(exc.Message)
            End Try

            ' Redraw form content
            Redraw(CreateGraphics())

        End Sub

        Private Sub UncheckAllAngleTolerances()
            ' Uncheck all angle tolerance menu items
            TolerancesAngle0.Checked = False
            TolerancesAngle5.Checked = False
            TolerancesAngle10.Checked = False
            TolerancesAngle90.Checked = False
            TolerancesAngle180.Checked = False
        End Sub

        Private Sub TolerancesAngle0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TolerancesAngle0.Click
            ' Set angle tolerance to 0?(none)
            m_Matcher.MinAngle = 0
            m_Matcher.MaxAngle = 0

            ' Set menu item checks
            UncheckAllAngleTolerances()
            TolerancesAngle0.Checked = True
        End Sub

        Private Sub TolerancesAngle5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TolerancesAngle5.Click
            ' Set angle tolerance to +/- 5?
            m_Matcher.MinAngle = -5
            m_Matcher.MaxAngle = 5

            ' Set menu item checks
            UncheckAllAngleTolerances()
            TolerancesAngle5.Checked = True
        End Sub

        Private Sub TolerancesAngle10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TolerancesAngle10.Click
            ' Set angle tolerance to +/- 10?
            m_Matcher.MinAngle = -10
            m_Matcher.MaxAngle = 10

            ' Set menu item checks
            UncheckAllAngleTolerances()
            TolerancesAngle10.Checked = True
        End Sub

        Private Sub TolerancesAngle90_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TolerancesAngle90.Click
            ' Set angle tolerance to +/- 90?(half turn)
            m_Matcher.MinAngle = -90
            m_Matcher.MaxAngle = 90

            ' Set menu item checks
            UncheckAllAngleTolerances()
            TolerancesAngle90.Checked = True
        End Sub

        Private Sub TolerancesAngle180_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TolerancesAngle180.Click
            ' Set angle tolerance to +/- 180?(full turn)
            m_Matcher.MinAngle = -180
            m_Matcher.MaxAngle = 180

            ' Set menu item checks
            UncheckAllAngleTolerances()
            TolerancesAngle180.Checked = True
        End Sub

        Private Sub UncheckAllScalingTolerances()
            ' Uncheck all scaling tolerance menu items
            TolerancesScaling0.Checked = False
            TolerancesScaling5.Checked = False
            TolerancesScaling10.Checked = False
            TolerancesScaling25.Checked = False
            TolerancesScaling50.Checked = False
        End Sub

        Private Sub TolerancesScaling0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TolerancesScaling0.Click
            ' Set scaling tolerance to 0%
            m_Matcher.MinScale = 0
            m_Matcher.MaxScale = 0

            ' Set menu item checks
            UncheckAllScalingTolerances()
            TolerancesScaling0.Checked = True
        End Sub

        Private Sub TolerancesScaling5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TolerancesScaling5.Click
            ' Set scaling tolerance to +/- 5%
            m_Matcher.MinScale = 0.95F
            m_Matcher.MaxScale = 1.05F

            ' Set menu item checks
            UncheckAllScalingTolerances()
            TolerancesScaling5.Checked = True
        End Sub

        Private Sub TolerancesScaling10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TolerancesScaling10.Click
            ' Set scaling tolerance to +/- 10%
            m_Matcher.MinScale = 0.9F
            m_Matcher.MaxScale = 1.1F

            ' Set menu item checks
            UncheckAllScalingTolerances()
            TolerancesScaling10.Checked = True
        End Sub

        Private Sub TolerancesScaling25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TolerancesScaling25.Click
            ' Set scaling tolerance to +/- 25%
            m_Matcher.MinScale = 0.75F
            m_Matcher.MaxScale = 1.25F

            ' Set menu item checks
            UncheckAllScalingTolerances()
            TolerancesScaling25.Checked = True
        End Sub

        Private Sub TolerancesScaling50_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TolerancesScaling50.Click
            ' Set scaling tolerance to +/- 50%
            m_Matcher.MinScale = 0.5F
            m_Matcher.MaxScale = 1.5F

            ' Set menu item checks
            UncheckAllScalingTolerances()
            TolerancesScaling50.Checked = True
        End Sub

        Private Sub MainForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        End Sub

        Private Sub ApplicationIntroduction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ApplicationIntroduction.Click
            MessageBox.Show("Load a gray level image using File/Open." & Chr(13) & "" & Chr(10) & "Drag and/or resize the region of interest to define your  " & Chr(13) & "" & Chr(10) & "pattern, then click 'Learn'." & Chr(13) & "" & Chr(10) & "Use the 'Tolerances' menu to adjust the matching tolerances.   " & Chr(13) & "" & Chr(10) & "Click 'Match' to trigger the pattern matching operation. " & Chr(13) & "" & Chr(10) & " " & Chr(13) & "" & Chr(10) & "Suggested image: any from the Images\EasyMatch folder." & Chr(13) & "" & Chr(10) & "" & Chr(13) & "" & Chr(10) & "Required license: EasyMatch.", "MchMatch", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        Private components As System.ComponentModel.IContainer
        Friend WithEvents Button1 As Button

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            Dim ang As Double
            Dim PosX As Double
            Dim PosY As Double

            PictureBox1.Load("D:\YongWei Gao\Desktop\Match1\新增資料夾\Die Pad 2.bmp")
            m_Matcher.Load("D:\YongWei Gao\Desktop\Match1\新增資料夾\diepad.MCH")
            m_Source.Load("D:\YongWei Gao\Desktop\Match1\新增資料夾\Die Pad 2.bmp")

            m_Matcher.MinAngle = -90
            m_Matcher.MaxAngle = 90
            m_Matcher.Match(m_Source)
            Dim dd As Integer = m_Matcher.NumPositions
            If (m_Matcher.NumPositions > 0) Then
                Dim my As EMatchPosition = m_Matcher.GetPosition(0)

                ang = my.Angle
                PosX = my.CenterX
                PosY = my.CenterY
            End If
            Label5.Text = Math.Round(ang, 2)
            Label1.Text = Math.Round(PosX, 2)
            Label2.Text = Math.Round(PosY, 2)
            Refresh()

        End Sub
        Friend WithEvents PictureBox1 As PictureBox





        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents Button4 As Button

        Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
            Dim ang As Double
            Dim PosX As Double
            Dim PosY As Double

            PictureBox1.Load("D:\YongWei Gao\Desktop\Match1\新增資料夾\0.bmp")


            m_Matcher.Load("D:\YongWei Gao\Desktop\Match1\新增資料夾\Bear.MCH")

            m_Source.Load("D:\YongWei Gao\Desktop\Match1\新增資料夾\0.bmp")


            m_Matcher.MinAngle = -90
            m_Matcher.MaxAngle = 90

            m_Matcher.Match(m_Source)



            If (m_Matcher.NumPositions > 0) Then
                Dim my As EMatchPosition = m_Matcher.GetPosition(0)
                ang = my.Angle
                PosX = my.CenterX
                PosY = my.CenterY
            End If

            Label5.Text = Math.Round(ang, 2)
            Label1.Text = Math.Round(PosX, 2)
            Label2.Text = Math.Round(PosY, 2)

            Refresh()
        End Sub

        Friend WithEvents PictureBox2 As PictureBox
        Friend WithEvents Button2 As Button

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
            Dim ang As Double
            Dim PosX As Double
            Dim PosY As Double
            Dim Score As Double
            Dim filename As String

            Label16.Text = "THHS"
            Pic_times += 1


            filename = "D:\YongWei Gao\Desktop\Match1\新增資料夾\MemsMap" + Pic_times.ToString + ".bmp"



            PictureBox1.Load(filename)
            m_Matcher.Load("D:\YongWei Gao\Desktop\Match1\新增資料夾\Mems.MCH")

            m_Source.Load(filename)


            m_Matcher.MinAngle = -90
            m_Matcher.MaxAngle = 90
            m_Matcher.Match(m_Source)



            If (m_Matcher.NumPositions > 0) Then
                Dim my As EMatchPosition = m_Matcher.GetPosition(0)
                Score = my.Score
                ang = my.Angle
                PosX = my.CenterX
                PosY = my.CenterY
            End If


            Label5.Text = Math.Round(ang, 2)
            Label1.Text = Math.Round(PosX, 2)
            Label2.Text = Math.Round(PosY, 2)
            Label8.Text = Math.Round(Score, 2)
            Refresh()


            If Label5.Text > -30 And Label5.Text < 30 Then
                Pic_check.Image = Image.FromFile("D:\\OK.BMP")
                Label11.Text += 1
            Else
                Pic_check.Image = Image.FromFile("D:\\NG.BMP")
                Label14.Text += 1
            End If
            Label12.Text += 1

        End Sub

        Friend WithEvents Button3 As Button
        Friend WithEvents Timer1 As Timer
        Friend WithEvents Label3 As Label
        Friend WithEvents Label4 As Label
        Friend WithEvents Label5 As Label
        Friend WithEvents Label6 As Label
        Friend WithEvents Label7 As Label
        Friend WithEvents Label8 As Label

        Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
            Dim ang As Double
            Dim PosX As Double
            Dim PosY As Double

            PictureBox1.Load("D:\YongWei Gao\Desktop\Match1\新增資料夾\Die Pad 2.bmp")
            m_Matcher.Load("D:\YongWei Gao\Desktop\Match1\新增資料夾\diepad.MCH")
            m_Source.Load("D:\YongWei Gao\Desktop\Match1\新增資料夾\Die Pad 2.bmp")

            m_Matcher.MinAngle = -90
            m_Matcher.MaxAngle = 90
            m_Matcher.Match(m_Source)
            Dim dd As Integer = m_Matcher.NumPositions
            If (m_Matcher.NumPositions > 0) Then
                Dim my As EMatchPosition = m_Matcher.GetPosition(0)

                ang = my.Angle
                PosX = my.CenterX
                PosY = my.CenterY
            End If
            Label5.Text = Math.Round(ang, 2)
            Label1.Text = Math.Round(PosX, 2)
            Label2.Text = Math.Round(PosY, 2)
            Refresh()


        End Sub

        Friend WithEvents PictureBox3 As PictureBox
        Friend WithEvents Pic_check As PictureBox

        Private Sub 說明LToolStripButton_Click(sender As Object, e As EventArgs)
            MessageBox.Show("Load a gray level image using File/Open." & Chr(13) & "" & Chr(10) & "Drag and/or resize the region of interest to define your  " & Chr(13) & "" & Chr(10) & "pattern, then click 'Learn'." & Chr(13) & "" & Chr(10) & "Use the 'Tolerances' menu to adjust the matching tolerances.   " & Chr(13) & "" & Chr(10) & "Click 'Match' to trigger the pattern matching operation. " & Chr(13) & "" & Chr(10) & " " & Chr(13) & "" & Chr(10) & "Suggested image: any from the Images\EasyMatch folder." & Chr(13) & "" & Chr(10) & "" & Chr(13) & "" & Chr(10) & "Required license: EasyMatch.", "MchMatch", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub



        Friend WithEvents Label10 As Label
        Friend WithEvents Label11 As Label
        Friend WithEvents Label12 As Label
        Friend WithEvents Label13 As Label
        Friend WithEvents Label14 As Label
        Friend WithEvents Label15 As Label
        Friend WithEvents PictureBox4 As PictureBox
        Friend WithEvents Button5 As Button

        Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
            Dim ang As Double
            Dim PosX As Double
            Dim PosY As Double
            Dim Score As Double
            Dim filename As String


            Pic_times += 1


            filename = "D:\YongWei Gao\Desktop\Match1\Frame\Frame" + Pic_times.ToString + ".tif"



            PictureBox1.Load(filename)
            m_Matcher.Load("D:\YongWei Gao\Desktop\Match1\Frame\Frame.MCH")

            m_Source.Load(filename)


            m_Matcher.MinAngle = -90
            m_Matcher.MaxAngle = 90
            m_Matcher.Match(m_Source)



            If (m_Matcher.NumPositions > 0) Then
                Dim my As EMatchPosition = m_Matcher.GetPosition(0)
                Score = my.Score
                ang = my.Angle
                PosX = my.CenterX
                PosY = my.CenterY
            End If


            Label5.Text = Math.Round(ang, 2)
            Label1.Text = Math.Round(PosX, 2)
            Label2.Text = Math.Round(PosY, 2)
            Label8.Text = Math.Round(Score, 2)
            Refresh()


            If Label5.Text > -30 And Label5.Text < 30 Then
                Pic_check.Image = Image.FromFile("D:\\OK.BMP")
                Label11.Text += 1
            Else
                Pic_check.Image = Image.FromFile("D:\\NG.BMP")
                Label14.Text += 1
            End If
            Label12.Text += 1

        End Sub

        Friend WithEvents Label9 As Label
        Friend WithEvents Label16 As Label

        Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
            Dim ang As Double
            Dim PosX As Double
            Dim PosY As Double
            Dim Score As Double
            Dim filename As String

            Label16.Text = "THHS"
            Pic_times += 1


            filename = "D:\YongWei Gao\Desktop\Match1\新增資料夾\MemsMap" + Pic_times.ToString + ".bmp"


            Try
                PictureBox1.Load(filename)


                m_Matcher.Load("D:\YongWei Gao\Desktop\Match1\新增資料夾\Mems.MCH")

                m_Source.Load(filename)


                m_Matcher.MinAngle = -90
                m_Matcher.MaxAngle = 90
                m_Matcher.Match(m_Source)



                If (m_Matcher.NumPositions > 0) Then
                    Dim my As EMatchPosition = m_Matcher.GetPosition(0)
                    Score = my.Score
                    ang = my.Angle
                    PosX = my.CenterX
                    PosY = my.CenterY
                End If


                Label5.Text = Math.Round(ang, 2)
                Label1.Text = Math.Round(PosX, 2)
                Label2.Text = Math.Round(PosY, 2)
                Label8.Text = Math.Round(Score, 2)
                Refresh()


                If Label5.Text > -30 And Label5.Text < 30 Then
                    Pic_check.Image = Image.FromFile("D:\\OK.BMP")
                    Label11.Text += 1
                Else
                    Pic_check.Image = Image.FromFile("D:\\NG.BMP")
                    Label14.Text += 1
                End If
                Label12.Text += 1


            Catch ex As Exception
                Timer1.Enabled = False
            End Try
        End Sub

        Friend WithEvents Button6 As Button

        Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
            If Timer1.Enabled = True Then
                Timer1.Enabled = False
                Button6.Text = "開始檢測"
            Else
                Timer1.Enabled = True
                Button6.Text = "暫停檢測"
            End If

        End Sub

        Private WithEvents statusBar As StatusBar
    End Class
End Namespace
