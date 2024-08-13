Public Class ctlKeyboard

    Public txtBox As New Label

    Public Event EnterButtonClicked()

    Private NumericOnlyMode As Boolean = False

#Region "pnlArabicLevel1"

    Private Sub bntArabicLevel1001_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1001.MouseDown
        txtBox.Text &= "ص"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1002_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1002.MouseDown
        txtBox.Text &= "ث"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1003_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1003.MouseDown
        txtBox.Text &= "ق"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1004_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1004.MouseDown
        txtBox.Text &= "ف"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1005_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1005.MouseDown
        txtBox.Text &= "غ"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1006_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1006.MouseDown
        txtBox.Text &= "ع"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1007_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1007.MouseDown
        txtBox.Text &= "ه"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1008_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1008.MouseDown
        txtBox.Text &= "خ"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1009_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1009.MouseDown
        txtBox.Text &= "ح"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1010_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1010.MouseDown
        txtBox.Text &= "ج"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1011_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1011.MouseDown
        txtBox.Text &= "ة"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1012_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1012.MouseDown
        txtBox.Text &= "ش"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1013_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1013.MouseDown
        txtBox.Text &= "س"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1014_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1014.MouseDown
        txtBox.Text &= "ي"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1015_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1015.MouseDown
        txtBox.Text &= "ب"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1016_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1016.MouseDown
        txtBox.Text &= "ل"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1017_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1017.MouseDown
        txtBox.Text &= "ا"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1018_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1018.MouseDown
        txtBox.Text &= "ت"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1019_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1019.MouseDown
        txtBox.Text &= "ن"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1020_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1020.MouseDown
        txtBox.Text &= "م"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1021_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1021.MouseDown
        txtBox.Text &= "ك"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1022_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1022.MouseDown
        txtBox.Text &= "ض"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1023_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1023.MouseDown

        pnlArabicLevel2.Visible = True
        pnlArabicLevel1.Visible = False
        pnlEnglishCapital.Visible = False
        pnlEnglishSmall.Visible = False
        pnlSpecialCharactersLevel1.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

    Private Sub bntArabicLevel1024_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1024.MouseDown
        txtBox.Text &= "ظ"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1025_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1025.MouseDown
        txtBox.Text &= "ط"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1026_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1026.MouseDown
        txtBox.Text &= "ذ"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1027_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1027.MouseDown
        txtBox.Text &= "د"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1028_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1028.MouseDown
        txtBox.Text &= "ز"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1029_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1029.MouseDown
        txtBox.Text &= "ر"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1030_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1030.MouseDown
        txtBox.Text &= "و"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1031_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1031.MouseDown
        If txtBox.Text.Length > 0 Then
            txtBox.Text = txtBox.Text.Substring(0, txtBox.Text.Length - 1)
        End If
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1032_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1032.MouseDown

        RaiseEvent EnterButtonClicked()

    End Sub

    Private Sub bntArabicLevel1033_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1033.MouseDown

        pnlSpecialCharactersLevel1.Visible = True
        pnlArabicLevel1.Visible = False
        pnlArabicLevel2.Visible = False
        pnlEnglishCapital.Visible = False
        pnlEnglishSmall.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

    Private Sub bntArabicLevel1034_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1034.MouseDown
        txtBox.Text &= " "
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1035_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1035.MouseDown
        txtBox.Text &= ".com"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1036_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1036.MouseDown
        txtBox.Text &= "@"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel1037_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel1037.MouseDown

        pnlEnglishCapital.Visible = True
        pnlArabicLevel1.Visible = False
        pnlArabicLevel2.Visible = False
        pnlEnglishSmall.Visible = False
        pnlSpecialCharactersLevel1.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

#End Region

#Region "pnlArabicLevel2"

    Private Sub bntArabicLevel2001_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2001.MouseDown
        txtBox.Text &= "ص"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2002_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2002.MouseDown
        txtBox.Text &= "ث"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2003_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2003.MouseDown
        txtBox.Text &= "ق"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2004_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2004.MouseDown
        txtBox.Text &= "ف"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2005_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2005.MouseDown
        txtBox.Text &= "غ"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2006_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2006.MouseDown
        txtBox.Text &= "ع"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2007_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2007.MouseDown
        txtBox.Text &= "ه"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2008_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2008.MouseDown
        txtBox.Text &= "خ"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2009_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2009.MouseDown
        txtBox.Text &= "ح"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2010_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2010.MouseDown
        txtBox.Text &= "ج"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2011_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2011.MouseDown
        txtBox.Text &= "ة"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2012_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2012.MouseDown
        txtBox.Text &= "ش"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2013_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2013.MouseDown
        txtBox.Text &= "س"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2014_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2014.MouseDown
        txtBox.Text &= "ى"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2015_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2015.MouseDown
        txtBox.Text &= "ب"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2016_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2016.MouseDown
        txtBox.Text &= "ل"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2017_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2017.MouseDown
        txtBox.Text &= "آ"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2018_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2018.MouseDown
        txtBox.Text &= "ت"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2019_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2019.MouseDown
        txtBox.Text &= "ن"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2020_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2020.MouseDown
        txtBox.Text &= "م"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2021_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2021.MouseDown
        txtBox.Text &= "ك"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2022_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2022.MouseDown
        txtBox.Text &= "ض"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2023_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2023.MouseDown

        pnlArabicLevel1.Visible = True
        pnlArabicLevel2.Visible = False
        pnlEnglishCapital.Visible = False
        pnlEnglishSmall.Visible = False
        pnlSpecialCharactersLevel1.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

    Private Sub bntArabicLevel2024_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2024.MouseDown
        txtBox.Text &= "ظ"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2025_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2025.MouseDown
        txtBox.Text &= "ط"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2026_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2026.MouseDown
        txtBox.Text &= "ئ"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2027_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2027.MouseDown
        txtBox.Text &= "ء"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2028_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2028.MouseDown
        txtBox.Text &= "أ"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2029_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2029.MouseDown
        txtBox.Text &= "إ"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2030_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2030.MouseDown
        txtBox.Text &= "ؤ"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2031_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2031.MouseDown
        If txtBox.Text.Length > 0 Then
            txtBox.Text = txtBox.Text.Substring(0, txtBox.Text.Length - 1)
        End If
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2032_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2032.MouseDown

        RaiseEvent EnterButtonClicked()

    End Sub

    Private Sub bntArabicLevel2033_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2033.MouseDown

        pnlSpecialCharactersLevel1.Visible = True
        pnlArabicLevel1.Visible = False
        pnlArabicLevel2.Visible = False
        pnlEnglishCapital.Visible = False
        pnlEnglishSmall.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

    Private Sub bntArabicLevel2034_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2034.MouseDown
        txtBox.Text &= " "
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2035_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2035.MouseDown
        txtBox.Text &= ".com"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2036_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2036.MouseDown
        txtBox.Text &= "@"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntArabicLevel2037_MouseDown(sender As Object, e As MouseEventArgs) Handles bntArabicLevel2037.MouseDown

        pnlEnglishCapital.Visible = True
        pnlArabicLevel1.Visible = False
        pnlArabicLevel2.Visible = False
        pnlEnglishSmall.Visible = False
        pnlSpecialCharactersLevel1.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

#End Region

#Region "pnlEnglishCapital"

    Private Sub bntEnglishCapital001_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital001.MouseDown
        txtBox.Text &= "Q"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital002_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital002.MouseDown
        txtBox.Text &= "W"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital003_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital003.MouseDown
        txtBox.Text &= "E"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital004_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital004.MouseDown
        txtBox.Text &= "R"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital005_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital005.MouseDown
        txtBox.Text &= "T"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital006_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital006.MouseDown
        txtBox.Text &= "Y"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital007_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital007.MouseDown
        txtBox.Text &= "U"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital008_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital008.MouseDown
        txtBox.Text &= "I"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital009_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital009.MouseDown
        txtBox.Text &= "O"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital010_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital010.MouseDown
        txtBox.Text &= "P"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital011_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital011.MouseDown
        txtBox.Text &= "A"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital012_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital012.MouseDown
        txtBox.Text &= "S"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital013_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital013.MouseDown
        txtBox.Text &= "D"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital014_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital014.MouseDown
        txtBox.Text &= "F"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital015_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital015.MouseDown
        txtBox.Text &= "G"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital016_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital016.MouseDown
        txtBox.Text &= "H"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital017_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital017.MouseDown
        txtBox.Text &= "J"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital018_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital018.MouseDown
        txtBox.Text &= "K"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital019_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital019.MouseDown
        txtBox.Text &= "L"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital020_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital020.MouseDown
        If txtBox.Text.Length > 0 Then
            txtBox.Text = txtBox.Text.Substring(0, txtBox.Text.Length - 1)
        End If
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital021_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital021.MouseDown

        pnlEnglishSmall.Visible = True
        pnlArabicLevel1.Visible = False
        pnlArabicLevel2.Visible = False
        pnlEnglishCapital.Visible = False
        pnlSpecialCharactersLevel1.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

    Private Sub bntEnglishCapital022_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital022.MouseDown
        txtBox.Text &= "Z"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital023_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital023.MouseDown
        txtBox.Text &= "X"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital024_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital024.MouseDown
        txtBox.Text &= "C"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital025_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital025.MouseDown
        txtBox.Text &= "V"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital026_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital026.MouseDown
        txtBox.Text &= "B"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital027_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital027.MouseDown
        txtBox.Text &= "N"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital028_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital028.MouseDown
        txtBox.Text &= "M"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital029_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital029.MouseDown

        RaiseEvent EnterButtonClicked()

    End Sub

    Private Sub bntEnglishCapital030_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital030.MouseDown

        pnlSpecialCharactersLevel1.Visible = True
        pnlArabicLevel1.Visible = False
        pnlArabicLevel2.Visible = False
        pnlEnglishCapital.Visible = False
        pnlEnglishSmall.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

    Private Sub bntEnglishCapital031_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital031.MouseDown
        txtBox.Text &= " "
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital032_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital032.MouseDown
        txtBox.Text &= ".com"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital033_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital033.MouseDown
        txtBox.Text &= "@"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishCapital034_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishCapital034.MouseDown

        pnlArabicLevel1.Visible = True
        pnlArabicLevel2.Visible = False
        pnlEnglishCapital.Visible = False
        pnlEnglishSmall.Visible = False
        pnlSpecialCharactersLevel1.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

#End Region

#Region "pnlEnglishSmall"

    Private Sub bntEnglishSmall001_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall001.MouseDown
        txtBox.Text &= "q"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall002_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall002.MouseDown
        txtBox.Text &= "w"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall003_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall003.MouseDown
        txtBox.Text &= "e"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall004_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall004.MouseDown
        txtBox.Text &= "r"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall005_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall005.MouseDown
        txtBox.Text &= "t"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall006_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall006.MouseDown
        txtBox.Text &= "y"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall007_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall007.MouseDown
        txtBox.Text &= "u"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall008_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall008.MouseDown
        txtBox.Text &= "i"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall009_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall009.MouseDown
        txtBox.Text &= "o"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall010_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall010.MouseDown
        txtBox.Text &= "p"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall011_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall011.MouseDown
        txtBox.Text &= "a"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall012_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall012.MouseDown
        txtBox.Text &= "s"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall013_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall013.MouseDown
        txtBox.Text &= "d"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall014_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall014.MouseDown
        txtBox.Text &= "f"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall015_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall015.MouseDown
        txtBox.Text &= "g"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall016_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall016.MouseDown
        txtBox.Text &= "h"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall017_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall017.MouseDown
        txtBox.Text &= "j"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall018_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall018.MouseDown
        txtBox.Text &= "k"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall019_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall019.MouseDown
        txtBox.Text &= "l"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall020_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall020.MouseDown
        If txtBox.Text.Length > 0 Then
            txtBox.Text = txtBox.Text.Substring(0, txtBox.Text.Length - 1)
        End If
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall021_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall021.MouseDown

        pnlEnglishCapital.Visible = True
        pnlArabicLevel1.Visible = False
        pnlArabicLevel2.Visible = False
        pnlEnglishSmall.Visible = False
        pnlSpecialCharactersLevel1.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

    Private Sub bntEnglishSmall022_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall022.MouseDown
        txtBox.Text &= "z"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall023_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall023.MouseDown
        txtBox.Text &= "x"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall024_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall024.MouseDown
        txtBox.Text &= "c"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall025_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall025.MouseDown
        txtBox.Text &= "v"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall026_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall026.MouseDown
        txtBox.Text &= "b"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall027_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall027.MouseDown
        txtBox.Text &= "n"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall028_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall028.MouseDown
        txtBox.Text &= "m"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall029_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall029.MouseDown

        RaiseEvent EnterButtonClicked()

    End Sub

    Private Sub bntEnglishSmall030_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall030.MouseDown

        pnlSpecialCharactersLevel1.Visible = True
        pnlArabicLevel1.Visible = False
        pnlArabicLevel2.Visible = False
        pnlEnglishCapital.Visible = False
        pnlEnglishSmall.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

    Private Sub bntEnglishSmall031_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall031.MouseDown
        txtBox.Text &= " "
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall032_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall032.MouseDown
        txtBox.Text &= ".com"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall033_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall033.MouseDown
        txtBox.Text &= "@"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub bntEnglishSmall034_MouseDown(sender As Object, e As MouseEventArgs) Handles bntEnglishSmall034.MouseDown

        pnlArabicLevel1.Visible = True
        pnlArabicLevel2.Visible = False
        pnlEnglishCapital.Visible = False
        pnlEnglishSmall.Visible = False
        pnlSpecialCharactersLevel1.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

#End Region

#Region "pnlSpecialCharactersLevel1"

    Private Sub btnSpecialCharactersLevel1001_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1001.MouseDown
        txtBox.Text &= "1"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel1002_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1002.MouseDown
        txtBox.Text &= "2"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel1003_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1003.MouseDown
        txtBox.Text &= "3"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel1004_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1004.MouseDown
        txtBox.Text &= "4"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel1005_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1005.MouseDown
        txtBox.Text &= "5"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel1006_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1006.MouseDown
        txtBox.Text &= "6"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel1007_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1007.MouseDown
        txtBox.Text &= "7"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel1008_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1008.MouseDown
        txtBox.Text &= "8"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel1009_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1009.MouseDown
        txtBox.Text &= "9"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel1010_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1010.MouseDown
        txtBox.Text &= "0"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel1011_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1011.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= "-"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1012_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1012.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= "/"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1013_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1013.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= ":"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1014_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1014.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= ";"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1015_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1015.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= "("
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1016_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1016.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= ")"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1017_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1017.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= "$"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1018_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1018.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= "&"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1019_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1019.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= "@"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1020_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1020.MouseDown
        If txtBox.Text.Length > 0 Then
            txtBox.Text = txtBox.Text.Substring(0, txtBox.Text.Length - 1)
        End If
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel1021_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1021.MouseDown

        If NumericOnlyMode = False Then
            pnlSpecialCharactersLevel2.Visible = True
            pnlArabicLevel1.Visible = False
            pnlArabicLevel2.Visible = False
            pnlEnglishCapital.Visible = False
            pnlEnglishSmall.Visible = False
            pnlSpecialCharactersLevel1.Visible = False
        End If

    End Sub

    Private Sub btnSpecialCharactersLevel1022_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1022.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= """"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1023_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1023.MouseDown
        txtBox.Text &= "."
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel1024_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1024.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= ","
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1025_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1025.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= "?"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1026_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1026.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= "!"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1027_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1027.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= "'"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1028_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1028.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= "*"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1029_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1029.MouseDown

        RaiseEvent EnterButtonClicked()

    End Sub

    Private Sub btnSpecialCharactersLevel1030_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1030.MouseDown

        If NumericOnlyMode = False Then
            pnlEnglishCapital.Visible = True
            pnlArabicLevel1.Visible = False
            pnlArabicLevel2.Visible = False
            pnlEnglishSmall.Visible = False
            pnlSpecialCharactersLevel1.Visible = False
            pnlSpecialCharactersLevel2.Visible = False
        End If

    End Sub

    Private Sub btnSpecialCharactersLevel1031_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1031.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= " "
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1032_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1032.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= ".com"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1033_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1033.MouseDown
        If NumericOnlyMode = False Then
            txtBox.Text &= "@"
            ChangeInputBoxBackColor()
        End If
    End Sub

    Private Sub btnSpecialCharactersLevel1034_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel1034.MouseDown

        If NumericOnlyMode = False Then
            pnlArabicLevel1.Visible = True
            pnlArabicLevel2.Visible = False
            pnlEnglishCapital.Visible = False
            pnlEnglishSmall.Visible = False
            pnlSpecialCharactersLevel1.Visible = False
            pnlSpecialCharactersLevel2.Visible = False
        End If

    End Sub

#End Region

#Region "pnlSpecialCharactersLevel2"

    Private Sub btnSpecialCharactersLevel2001_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2001.MouseDown
        txtBox.Text &= "1"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2002_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2002.MouseDown
        txtBox.Text &= "2"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2003_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2003.MouseDown
        txtBox.Text &= "3"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2004_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2004.MouseDown
        txtBox.Text &= "4"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2005_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2005.MouseDown
        txtBox.Text &= "5"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2006_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2006.MouseDown
        txtBox.Text &= "6"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2007_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2007.MouseDown
        txtBox.Text &= "7"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2008_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2008.MouseDown
        txtBox.Text &= "8"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2009_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2009.MouseDown
        txtBox.Text &= "9"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2010_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2010.MouseDown
        txtBox.Text &= "0"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2011_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2011.MouseDown
        txtBox.Text &= "["
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2012_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2012.MouseDown
        txtBox.Text &= "]"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2013_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2013.MouseDown
        txtBox.Text &= "{"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2014_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2014.MouseDown
        txtBox.Text &= "}"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2015_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2015.MouseDown
        txtBox.Text &= "#"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2016_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2016.MouseDown
        txtBox.Text &= "%"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2017_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2017.MouseDown
        txtBox.Text &= "^"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2018_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2018.MouseDown
        txtBox.Text &= "+"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2019_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2019.MouseDown
        txtBox.Text &= "="
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2020_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2020.MouseDown
        If txtBox.Text.Length > 0 Then
            txtBox.Text = txtBox.Text.Substring(0, txtBox.Text.Length - 1)
        End If
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2021_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2021.MouseDown

        pnlSpecialCharactersLevel1.Visible = True
        pnlArabicLevel1.Visible = False
        pnlArabicLevel2.Visible = False
        pnlEnglishCapital.Visible = False
        pnlEnglishSmall.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

    Private Sub btnSpecialCharactersLevel2022_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2022.MouseDown
        txtBox.Text &= "_"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2023_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2023.MouseDown
        txtBox.Text &= "\"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2024_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2024.MouseDown
        txtBox.Text &= "|"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2025_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2025.MouseDown
        txtBox.Text &= "<"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2026_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2026.MouseDown
        txtBox.Text &= ">"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2027_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2027.MouseDown
        txtBox.Text &= "~"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2028_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2028.MouseDown
        txtBox.Text &= "'"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2029_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2029.MouseDown

        RaiseEvent EnterButtonClicked()

    End Sub

    Private Sub btnSpecialCharactersLevel2030_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2030.MouseDown

        pnlEnglishCapital.Visible = True
        pnlArabicLevel1.Visible = False
        pnlArabicLevel2.Visible = False
        pnlEnglishSmall.Visible = False
        pnlSpecialCharactersLevel1.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

    Private Sub btnSpecialCharactersLevel2031_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2031.MouseDown
        txtBox.Text &= " "
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2032_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2032.MouseDown
        txtBox.Text &= ".com"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2033_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2033.MouseDown
        txtBox.Text &= "@"
        ChangeInputBoxBackColor()
    End Sub

    Private Sub btnSpecialCharactersLevel2034_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSpecialCharactersLevel2034.MouseDown

        pnlArabicLevel1.Visible = True
        pnlArabicLevel2.Visible = False
        pnlEnglishCapital.Visible = False
        pnlEnglishSmall.Visible = False
        pnlSpecialCharactersLevel1.Visible = False
        pnlSpecialCharactersLevel2.Visible = False

    End Sub

#End Region

    Private Sub ChangeInputBoxBackColor()

        If txtBox.Text <> "" Then
            txtBox.BackColor = Color.White
        Else
            txtBox.BackColor = Color.Transparent
        End If

    End Sub

    Public Sub SetKeyboardMode(ByVal NumericOnly As Boolean)

        NumericOnlyMode = NumericOnly

        If NumericOnly = True Then
            pnlSpecialCharactersLevel1.Visible = True
            pnlArabicLevel1.Visible = False
            pnlArabicLevel2.Visible = False
            pnlEnglishCapital.Visible = False
            pnlEnglishSmall.Visible = False
            pnlSpecialCharactersLevel2.Visible = False
        Else
            pnlEnglishCapital.Visible = True
            pnlArabicLevel1.Visible = False
            pnlArabicLevel2.Visible = False
            pnlEnglishSmall.Visible = False
            pnlSpecialCharactersLevel1.Visible = False
            pnlSpecialCharactersLevel2.Visible = False
        End If

    End Sub

End Class
