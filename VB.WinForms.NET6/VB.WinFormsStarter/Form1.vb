Imports AnyCAD.Foundation

Public Class Form1

    Private mRenderView As AnyCAD.Forms.RenderControl

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalInstance.Initialize()
        mRenderView = New AnyCAD.Forms.RenderControl(SplitContainer1.Panel2)
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        GlobalInstance.Destroy()
    End Sub
End Class
