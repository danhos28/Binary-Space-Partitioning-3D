<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PBDraw = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pyr = New System.Windows.Forms.RadioButton()
        Me.prism = New System.Windows.Forms.RadioButton()
        CType(Me.PBDraw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PBDraw
        '
        Me.PBDraw.BackColor = System.Drawing.Color.White
        Me.PBDraw.Location = New System.Drawing.Point(12, 12)
        Me.PBDraw.Name = "PBDraw"
        Me.PBDraw.Size = New System.Drawing.Size(560, 400)
        Me.PBDraw.TabIndex = 0
        Me.PBDraw.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightBlue
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.RichTextBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.pyr)
        Me.Panel1.Controls.Add(Me.prism)
        Me.Panel1.Location = New System.Drawing.Point(583, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(220, 455)
        Me.Panel1.TabIndex = 7
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.SystemColors.MenuBar
        Me.RichTextBox1.Font = New System.Drawing.Font("Modern No. 20", 8.95!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(18, 109)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(187, 331)
        Me.RichTextBox1.TabIndex = 10
        Me.RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lucida Calligraphy", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 24)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "CONTROL"
        '
        'pyr
        '
        Me.pyr.AutoSize = True
        Me.pyr.BackColor = System.Drawing.Color.Transparent
        Me.pyr.Font = New System.Drawing.Font("Monotype Corsiva", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pyr.Location = New System.Drawing.Point(18, 77)
        Me.pyr.Name = "pyr"
        Me.pyr.Size = New System.Drawing.Size(92, 26)
        Me.pyr.TabIndex = 8
        Me.pyr.TabStop = True
        Me.pyr.Text = "Pyramid"
        Me.pyr.UseVisualStyleBackColor = False
        '
        'prism
        '
        Me.prism.AutoSize = True
        Me.prism.BackColor = System.Drawing.Color.Transparent
        Me.prism.Font = New System.Drawing.Font("Monotype Corsiva", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prism.Location = New System.Drawing.Point(18, 45)
        Me.prism.Name = "prism"
        Me.prism.Size = New System.Drawing.Size(72, 26)
        Me.prism.TabIndex = 7
        Me.prism.TabStop = True
        Me.prism.Text = "Prism"
        Me.prism.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Indigo
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PBDraw)
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.Text = "BSP PROGRAM"
        CType(Me.PBDraw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PBDraw As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents pyr As RadioButton
    Friend WithEvents prism As RadioButton
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
