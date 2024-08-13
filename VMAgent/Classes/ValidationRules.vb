Imports System.Text.RegularExpressions

Public Class ValidationRules

    Public Property ValidationRuleName As String = ""
    Public Property ValidationRuleDescription As String = ""

    Public Shared Function GetAllValidationRules() As List(Of ValidationRules)

        Dim ALValidationRules As New List(Of ValidationRules)

        Dim Rule1 As New ValidationRules
        Rule1.ValidationRuleName = "VR001"
        Rule1.ValidationRuleDescription = "Validate Email Address"
        ALValidationRules.Add(Rule1)

        Dim Rule2 As New ValidationRules
        Rule2.ValidationRuleName = "VR002"
        Rule2.ValidationRuleDescription = "Validate Positive Integer >= 0"
        ALValidationRules.Add(Rule2)

        Dim Rule3 As New ValidationRules
        Rule3.ValidationRuleName = "VR003"
        Rule3.ValidationRuleDescription = "Validate EN Alpha with space anywhere"
        ALValidationRules.Add(Rule3)

        Dim Rule4 As New ValidationRules
        Rule4.ValidationRuleName = "VR004"
        Rule4.ValidationRuleDescription = "Validate EN Alpha with space only between characters"
        ALValidationRules.Add(Rule4)

        Dim Rule5 As New ValidationRules
        Rule5.ValidationRuleName = "VR005"
        Rule5.ValidationRuleDescription = "Validate EN Alpha without space"
        ALValidationRules.Add(Rule5)

        Dim Rule6 As New ValidationRules
        Rule6.ValidationRuleName = "VR006"
        Rule6.ValidationRuleDescription = "Validate EN Alpha Numeric with space only between characters and start with Alpha"
        ALValidationRules.Add(Rule6)

        Dim Rule7 As New ValidationRules
        Rule7.ValidationRuleName = "VR007"
        Rule7.ValidationRuleDescription = "Validate EN Alpha Numeric with space anywhere"
        ALValidationRules.Add(Rule7)

        Dim Rule8 As New ValidationRules
        Rule8.ValidationRuleName = "VR008"
        Rule8.ValidationRuleDescription = "Validate EN Alpha without space with Underscore anywhere"
        ALValidationRules.Add(Rule8)

        Dim Rule9 As New ValidationRules
        Rule9.ValidationRuleName = "VR009"
        Rule9.ValidationRuleDescription = "Validate EN Alpha without space with Underscore only between characters"
        ALValidationRules.Add(Rule9)

        Dim Rule10 As New ValidationRules
        Rule10.ValidationRuleName = "VR010"
        Rule10.ValidationRuleDescription = "Validate EN Alpha Numeric without space"
        ALValidationRules.Add(Rule10)

        Dim Rule11 As New ValidationRules
        Rule11.ValidationRuleName = "VR011"
        Rule11.ValidationRuleDescription = "Validate EN Alpha Numeric without space and start with Alpha"
        ALValidationRules.Add(Rule11)

        Dim Rule12 As New ValidationRules
        Rule12.ValidationRuleName = "VR012"
        Rule12.ValidationRuleDescription = "Validate EN Alpha Numeric without space with Underscore anywhere"
        ALValidationRules.Add(Rule12)

        Dim Rule13 As New ValidationRules
        Rule13.ValidationRuleName = "VR013"
        Rule13.ValidationRuleDescription = "Validate EN Alpha Numeric without space with (.,_,-) only between characters and start with Alpha, ends with Alpha or Numeric"
        ALValidationRules.Add(Rule13)

        Dim Rule14 As New ValidationRules
        Rule14.ValidationRuleName = "VR014"
        Rule14.ValidationRuleDescription = "Validate Numeric without space and can start with zero"
        ALValidationRules.Add(Rule14)

        Dim Rule15 As New ValidationRules
        Rule15.ValidationRuleName = "VR015"
        Rule15.ValidationRuleDescription = "Validate EN Alpha Numeric with (space,.,_,-) only between characters and start with Alpha, ends with Alpha or Numeric"
        ALValidationRules.Add(Rule15)

        Dim Rule16 As New ValidationRules
        Rule16.ValidationRuleName = "VR016"
        Rule16.ValidationRuleDescription = "Validate EN Alpha Numeric without space with Underscore only between characters and start with Alpha"
        ALValidationRules.Add(Rule16)

        Dim Rule17 As New ValidationRules
        Rule17.ValidationRuleName = "VR017"
        Rule17.ValidationRuleDescription = "Validate Date format: dd/MM/yyyy"
        ALValidationRules.Add(Rule17)

        Dim Rule18 As New ValidationRules
        Rule18.ValidationRuleName = "VR018"
        Rule18.ValidationRuleDescription = "Validate Positive or Negative Integer"
        ALValidationRules.Add(Rule18)

        Dim Rule19 As New ValidationRules
        Rule19.ValidationRuleName = "VR019"
        Rule19.ValidationRuleDescription = "Validate Negative Integer < 0"
        ALValidationRules.Add(Rule19)

        Dim Rule20 As New ValidationRules
        Rule20.ValidationRuleName = "VR020"
        Rule20.ValidationRuleDescription = "Validate Positive or Negative Decimal"
        ALValidationRules.Add(Rule20)

        Dim Rule21 As New ValidationRules
        Rule21.ValidationRuleName = "VR021"
        Rule21.ValidationRuleDescription = "Validate Positive Decimal >= 0.0"
        ALValidationRules.Add(Rule21)

        Dim Rule22 As New ValidationRules
        Rule22.ValidationRuleName = "VR022"
        Rule22.ValidationRuleDescription = "Validate Negative Decimal < 0.0"
        ALValidationRules.Add(Rule22)

        Dim Rule23 As New ValidationRules
        Rule23.ValidationRuleName = "VR023"
        Rule23.ValidationRuleDescription = "Validate AR Alpha with space anywhere"
        ALValidationRules.Add(Rule23)

        Dim Rule24 As New ValidationRules
        Rule24.ValidationRuleName = "VR024"
        Rule24.ValidationRuleDescription = "Validate AR Alpha without space"
        ALValidationRules.Add(Rule24)

        Dim Rule25 As New ValidationRules
        Rule25.ValidationRuleName = "VR025"
        Rule25.ValidationRuleDescription = "Validate AR Alpha with space only between characters"
        ALValidationRules.Add(Rule25)

        Dim Rule26 As New ValidationRules
        Rule26.ValidationRuleName = "VR026"
        Rule26.ValidationRuleDescription = "Validate AR Alpha Numeric with space anywhere"
        ALValidationRules.Add(Rule26)

        Dim Rule27 As New ValidationRules
        Rule27.ValidationRuleName = "VR027"
        Rule27.ValidationRuleDescription = "Validate (EN only OR AR only) Alpha with space only between characters"
        ALValidationRules.Add(Rule27)

        Dim Rule28 As New ValidationRules
        Rule28.ValidationRuleName = "VR028"
        Rule28.ValidationRuleDescription = "Validate (EN only OR AR only) Alpha Numeric with space anywhere"
        ALValidationRules.Add(Rule28)

        Dim Rule29 As New ValidationRules
        Rule29.ValidationRuleName = "VR029"
        Rule29.ValidationRuleDescription = "Validate HTML color codes"
        ALValidationRules.Add(Rule29)

        Dim Rule30 As New ValidationRules
        Rule30.ValidationRuleName = "VR030"
        Rule30.ValidationRuleDescription = "Validate Palestinian ID number"
        ALValidationRules.Add(Rule30)

        Dim Rule31 As New ValidationRules
        Rule31.ValidationRuleName = "VR031"
        Rule31.ValidationRuleDescription = "Validate Time format: HH:mm"
        ALValidationRules.Add(Rule31)

        Dim Rule32 As New ValidationRules
        Rule32.ValidationRuleName = "VR032"
        Rule32.ValidationRuleDescription = "Validate Time format: HH:mm:ss"
        ALValidationRules.Add(Rule32)

        Dim Rule33 As New ValidationRules
        Rule33.ValidationRuleName = "VR033"
        Rule33.ValidationRuleDescription = "Validate Positive Integer > 0"
        ALValidationRules.Add(Rule33)

        Dim Rule34 As New ValidationRules
        Rule34.ValidationRuleName = "VR034"
        Rule34.ValidationRuleDescription = "Validate Positive Decimal > 0.0"
        ALValidationRules.Add(Rule34)

        Return ALValidationRules

    End Function

    'VR001: Validate Email Address
    Public Shared Function VR001(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim Pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(StringToCheck, Pattern)

        If emailAddressMatch.Success Then
            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR002: Validate Positive Integer >= 0
    Public Shared Function VR002(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^\d+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then

            Dim TempValue As String = StringToCheck

            While TempValue.StartsWith("0") = True And TempValue.Length > 1
                TempValue = TempValue.Substring(1)
            End While

            StringToCheck = TempValue

            IsValid = True

        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR003: Validate EN Alpha with space anywhere
    Public Shared Function VR003(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[a-zA-Z\s]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR004: Validate EN Alpha with space only between characters
    Public Shared Function VR004(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[a-zA-Z\s]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            If StringToCheck.StartsWith(" ") = True Or StringToCheck.EndsWith(" ") = True Then
                IsValid = False
            Else
                IsValid = True
            End If
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR005: Validate EN Alpha without space
    Public Shared Function VR005(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[a-zA-Z]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR006: Validate EN Alpha Numeric with space only between characters and start with Alpha
    Public Shared Function VR006(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[a-zA-Z0-9\s]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            If StringToCheck.StartsWith(" ") = True Or StringToCheck.EndsWith(" ") = True Or VR005(StringToCheck.Substring(0, 1)) = False Then
                IsValid = False
            Else
                IsValid = True
            End If
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR007: Validate EN Alpha Numeric with space anywhere
    Public Shared Function VR007(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[a-zA-Z0-9\s]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR008: Validate EN Alpha without space with Underscore anywhere
    Public Shared Function VR008(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[a-zA-Z_]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR009: Validate EN Alpha without space with Underscore only between characters
    Public Shared Function VR009(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[a-zA-Z_]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            If StringToCheck.StartsWith("_") = True Or StringToCheck.EndsWith("_") = True Then
                IsValid = False
            Else
                IsValid = True
            End If
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR010: Validate EN Alpha Numeric without space
    Public Shared Function VR010(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[a-zA-Z0-9]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR011: Validate EN Alpha Numeric without space and start with Alpha
    Public Shared Function VR011(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[a-zA-Z0-9]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            If VR005(StringToCheck.Substring(0, 1)) = False Then
                IsValid = False
            Else
                IsValid = True
            End If
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR012: Validate EN Alpha Numeric without space with Underscore anywhere
    Public Shared Function VR012(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[a-zA-Z0-9_]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR013: Validate EN Alpha Numeric without space with (.,_,-) only between characters and start with Alpha, ends with Alpha or Numeric
    Public Shared Function VR013(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[a-zA-Z0-9._\-]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            If StringToCheck.StartsWith(".") = True Or StringToCheck.StartsWith("_") = True Or StringToCheck.StartsWith("-") = True Or StringToCheck.EndsWith(".") = True Or StringToCheck.EndsWith("_") = True Or StringToCheck.EndsWith("-") = True Or VR005(StringToCheck.Substring(0, 1)) = False Then
                IsValid = False
            Else
                IsValid = True
            End If
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR014: Validate Numeric without space and can start with zero
    Public Shared Function VR014(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^\d+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR015: Validate EN Alpha Numeric with (space,.,_,-) only between characters and start with Alpha, ends with Alpha or Numeric
    Public Shared Function VR015(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[a-zA-Z0-9._\-\s]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            If StringToCheck.StartsWith(".") = True Or StringToCheck.StartsWith("_") = True Or StringToCheck.StartsWith("-") = True Or StringToCheck.StartsWith(" ") = True Or StringToCheck.EndsWith(".") = True Or StringToCheck.EndsWith("_") = True Or StringToCheck.EndsWith("-") = True Or StringToCheck.EndsWith(" ") = True Or VR005(StringToCheck.Substring(0, 1)) = False Then
                IsValid = False
            Else
                IsValid = True
            End If
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR016: Validate EN Alpha Numeric without space with Underscore only between characters and start with Alpha
    Public Shared Function VR016(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[a-zA-Z0-9_]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            If StringToCheck.StartsWith("_") = True Or StringToCheck.EndsWith("_") = True Or VR005(StringToCheck.Substring(0, 1)) = False Then
                IsValid = False
            Else
                IsValid = True
            End If
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR017: Validate Date format: dd/MM/yyyy
    Public Shared Function VR017(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim DT As Date
        If Date.TryParseExact(StringToCheck, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, DT) = True Then
            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR018: Validate Positive or Negative Integer
    Public Shared Function VR018(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^-?\d+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then

            Dim Sign As String = ""
            Dim TempValue As String = StringToCheck

            If TempValue.StartsWith("-") = True Then
                Sign = "-"
                TempValue = TempValue.Substring(1)
            End If

            While TempValue.StartsWith("0") And TempValue.Length > 1
                TempValue = TempValue.Substring(1)
            End While

            If TempValue = "0" Then
                StringToCheck = TempValue
            Else
                StringToCheck = Sign & TempValue
            End If

            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR019: Validate Negative Integer < 0
    Public Shared Function VR019(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^-\d+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then

            Dim TempValue As String = StringToCheck

            TempValue = TempValue.Substring(1)

            While TempValue.StartsWith("0") And TempValue.Length > 1
                TempValue = TempValue.Substring(1)
            End While

            If TempValue = "0" Then
                IsValid = False
            Else
                StringToCheck = "-" & TempValue
                IsValid = True
            End If

        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR020: Validate Positive or Negative Decimal
    Public Shared Function VR020(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^-?\d*\.?\d+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then

            Dim Sign As String = ""
            Dim TempValue As String = StringToCheck

            If TempValue.StartsWith("-") = True Then
                Sign = "-"
                TempValue = TempValue.Substring(1)
            End If

            Dim ValueParts() As String
            ValueParts = TempValue.Split(".")

            If ValueParts.Length = 1 Then
                IsValid = VR018(ValueParts(0))
                If IsValid = True Then
                    If ValueParts(0) = "0" Then
                        StringToCheck = ValueParts(0)
                    Else
                        StringToCheck = Sign & ValueParts(0)
                    End If
                End If
            Else

                If ValueParts(0) = "" Then
                    ValueParts(0) = "0"
                End If

                IsValid = VR018(ValueParts(0))
                If IsValid = True Then

                    While ValueParts(1).EndsWith("0")
                        ValueParts(1) = ValueParts(1).Substring(0, ValueParts(1).Length - 1)
                    End While

                    If ValueParts(1) <> "" Then
                        StringToCheck = Sign & ValueParts(0) & "." & ValueParts(1)
                    Else
                        If ValueParts(0) = "0" Then
                            StringToCheck = ValueParts(0)
                        Else
                            StringToCheck = Sign & ValueParts(0)
                        End If
                    End If

                End If

            End If

        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR021: Validate Positive Decimal >= 0.0
    Public Shared Function VR021(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^\d*\.?\d+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then

            Dim TempValue As String = StringToCheck

            Dim ValueParts() As String
            ValueParts = TempValue.Split(".")

            If ValueParts.Length = 1 Then
                IsValid = VR018(ValueParts(0))
                If IsValid = True Then
                    StringToCheck = ValueParts(0)
                End If
            Else

                If ValueParts(0) = "" Then
                    ValueParts(0) = "0"
                End If

                IsValid = VR018(ValueParts(0))
                If IsValid = True Then

                    While ValueParts(1).EndsWith("0")
                        ValueParts(1) = ValueParts(1).Substring(0, ValueParts(1).Length - 1)
                    End While

                    If ValueParts(1) <> "" Then
                        StringToCheck = ValueParts(0) & "." & ValueParts(1)
                    Else
                        StringToCheck = ValueParts(0)
                    End If

                End If

            End If

        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR022: Validate Negative Decimal < 0.0
    Public Shared Function VR022(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^-\d*\.?\d+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then

            Dim TempValue As String = StringToCheck

            TempValue = TempValue.Substring(1)

            Dim ValueParts() As String
            ValueParts = TempValue.Split(".")

            If ValueParts.Length = 1 Then
                IsValid = VR018(ValueParts(0))
                If IsValid = True Then
                    If ValueParts(0) = "0" Then
                        IsValid = False
                    Else
                        StringToCheck = "-" & ValueParts(0)
                    End If
                End If
            Else

                If ValueParts(0) = "" Then
                    ValueParts(0) = "0"
                End If

                IsValid = VR018(ValueParts(0))
                If IsValid = True Then

                    While ValueParts(1).EndsWith("0")
                        ValueParts(1) = ValueParts(1).Substring(0, ValueParts(1).Length - 1)
                    End While

                    If ValueParts(1) <> "" Then
                        StringToCheck = "-" & ValueParts(0) & "." & ValueParts(1)
                    Else
                        If ValueParts(0) = "0" Then
                            IsValid = False
                        Else
                            StringToCheck = "-" & ValueParts(0)
                        End If
                    End If

                End If

            End If

        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR023: Validate AR Alpha with space anywhere
    Public Shared Function VR023(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[\u0621-\u064A\040]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR024: Validate AR Alpha without space
    Public Shared Function VR024(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[\u0621-\u064A]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR025: Validate AR Alpha with space only between characters
    Public Shared Function VR025(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[\u0621-\u064A\040]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            If StringToCheck.StartsWith(" ") Or StringToCheck.EndsWith(" ") Then
                IsValid = False
            Else
                IsValid = True
            End If
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR026: Validate AR Alpha Numeric with space anywhere
    Public Shared Function VR026(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^[\u0621-\u064A0-9\040]+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then
            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR027: Validate (EN only OR AR only) Alpha with space only between characters
    Public Shared Function VR027(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        If ValidationRules.VR004(StringToCheck) = True Or ValidationRules.VR025(StringToCheck) = True Then
            IsValid = True
        End If

        Return IsValid

    End Function

    'VR028: Validate (EN only OR AR only) Alpha Numeric with space anywhere
    Public Shared Function VR028(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        If ValidationRules.VR007(StringToCheck) = True Or ValidationRules.VR026(StringToCheck) = True Then
            IsValid = True
        End If

        Return IsValid

    End Function

    'VR029: Validate HTML color codes
    Public Shared Function VR029(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        If StringToCheck.Length = 7 Then
            If StringToCheck.Substring(0, 1) = "#" Then
                If "0123456789abcdefABCDEF".Contains(StringToCheck.Substring(1, 1)) = True Then
                    If "0123456789abcdefABCDEF".Contains(StringToCheck.Substring(2, 1)) = True Then
                        If "0123456789abcdefABCDEF".Contains(StringToCheck.Substring(3, 1)) = True Then
                            If "0123456789abcdefABCDEF".Contains(StringToCheck.Substring(4, 1)) = True Then
                                If "0123456789abcdefABCDEF".Contains(StringToCheck.Substring(5, 1)) = True Then
                                    If "0123456789abcdefABCDEF".Contains(StringToCheck.Substring(6, 1)) = True Then
                                        IsValid = True
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If IsValid = False Then
            If StringToCheck.StartsWith("rgba(") = True And StringToCheck.EndsWith(")") = True Then
                Dim PARTS() As String
                PARTS = StringToCheck.Substring(5, StringToCheck.Length - 6).Split(",")
                If PARTS.Length = 4 Then
                    If ValidationRules.VR002(PARTS(0)) = True And ValidationRules.VR002(PARTS(1)) = True And ValidationRules.VR002(PARTS(2)) = True Then
                        If Val(PARTS(0)) >= 0 And Val(PARTS(0)) <= 255 And Val(PARTS(1)) >= 0 And Val(PARTS(1)) <= 255 And Val(PARTS(2)) >= 0 And Val(PARTS(2)) <= 255 Then
                            If IsNumeric(PARTS(3)) = True And PARTS(3).Length <= 4 And PARTS(3).StartsWith(".") = False Then
                                If Val(PARTS(3)) >= 0 And Val(PARTS(3)) <= 1 Then
                                    IsValid = True
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Return IsValid

    End Function

    'VR030: Validate Palestinian ID number
    Public Shared Function VR030(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        StringToCheck = StringToCheck.Trim

        If StringToCheck.Length = 9 Then
            If IsNumeric(StringToCheck) = True Then

                Dim DSM As Integer = 0
                Dim D1 As Integer = StringToCheck.Substring(0, 1)
                Dim D2 As Integer = StringToCheck.Substring(1, 1)
                Dim D3 As Integer = StringToCheck.Substring(2, 1)
                Dim D4 As Integer = StringToCheck.Substring(3, 1)
                Dim D5 As Integer = StringToCheck.Substring(4, 1)
                Dim D6 As Integer = StringToCheck.Substring(5, 1)
                Dim D7 As Integer = StringToCheck.Substring(6, 1)
                Dim D8 As Integer = StringToCheck.Substring(7, 1)

                Dim CD As Integer = StringToCheck.Substring(8, 1)

                Dim D8S As Integer = D8 * 2
                If (D8S.ToString().Length = 2) Then
                    D8S = Val(D8S.ToString.Substring(0, 1)) + Val(D8S.ToString.Substring(1, 1))
                End If

                DSM = DSM + D8S

                DSM = DSM + D7

                Dim D6S As Integer = D6 * 2
                If (D6S.ToString().Length = 2) Then
                    D6S = Val(D6S.ToString.Substring(0, 1)) + Val(D6S.ToString.Substring(1, 1))
                End If

                DSM = DSM + D6S

                DSM = DSM + D5

                Dim D4S As Integer = D4 * 2
                If (D4S.ToString().Length = 2) Then
                    D4S = Val(D4S.ToString.Substring(0, 1)) + Val(D4S.ToString.Substring(1, 1))
                End If

                DSM = DSM + D4S

                DSM = DSM + D3

                Dim D2S As Integer = D2 * 2
                If (D2S.ToString().Length = 2) Then
                    D2S = Val(D2S.ToString.Substring(0, 1)) + Val(D2S.ToString.Substring(1, 1))
                End If

                DSM = DSM + D2S

                DSM = DSM + D1

                Dim DSMStr As String = DSM

                If DSMStr.Length = 1 Then
                    DSMStr = "0" & DSMStr
                End If

                If Val(DSMStr.Substring(1, 1)) = 0 Then
                    If (CD = 0) Then
                        IsValid = True
                    Else
                        IsValid = False
                    End If
                Else
                    If (10 - Val(DSMStr.Substring(1, 1)) = CD) Then
                        IsValid = True
                    Else
                        IsValid = False
                    End If
                End If

            Else
                IsValid = False
            End If
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR031: Validate Time format: HH:mm
    Public Shared Function VR031(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim DT As Date
        If Date.TryParseExact(StringToCheck, "HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, DT) = True Then
            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR032: Validate Time format: HH:mm:ss
    Public Shared Function VR032(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim DT As Date
        If Date.TryParseExact(StringToCheck, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, DT) = True Then
            IsValid = True
        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR033: Validate Positive Integer > 0
    Public Shared Function VR033(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^\d+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then

            Dim TempValue As String = StringToCheck

            While TempValue.StartsWith("0") = True And TempValue.Length > 1
                TempValue = TempValue.Substring(1)
            End While

            If TempValue = "0" Then
                IsValid = False
            Else
                StringToCheck = TempValue
                IsValid = True
            End If

        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    'VR034: Validate Positive Decimal > 0.0
    Public Shared Function VR034(ByRef StringToCheck As String) As Boolean

        Dim IsValid As Boolean = False

        Dim pattern As String = "^\d*\.?\d+$"
        Dim reg As New Regex(pattern)

        If reg.IsMatch(StringToCheck) Then

            Dim TempValue As String = StringToCheck

            Dim ValueParts() As String
            ValueParts = TempValue.Split(".")

            If ValueParts.Length = 1 Then
                IsValid = VR018(ValueParts(0))
                If IsValid = True Then
                    If ValueParts(0) = "0" Then
                        IsValid = False
                    Else
                        StringToCheck = ValueParts(0)
                    End If
                End If
            Else

                If ValueParts(0) = "" Then
                    ValueParts(0) = "0"
                End If

                IsValid = VR018(ValueParts(0))
                If IsValid = True Then

                    While ValueParts(1).EndsWith("0")
                        ValueParts(1) = ValueParts(1).Substring(0, ValueParts(1).Length - 1)
                    End While

                    If ValueParts(1) <> "" Then
                        StringToCheck = ValueParts(0) & "." & ValueParts(1)
                    Else
                        If ValueParts(0) = "0" Then
                            IsValid = False
                        Else
                            StringToCheck = ValueParts(0)
                        End If
                    End If

                End If

            End If

        Else
            IsValid = False
        End If

        Return IsValid

    End Function

    Public Shared Function CheckAgainstValidationRule(ByRef StringToCheck As String, ByVal ValidationRuleName As String) As Boolean

        Dim IsValid As Boolean = False

        If ValidationRuleName = "VR001" Then
            IsValid = ValidationRules.VR001(StringToCheck)
        End If
        If ValidationRuleName = "VR002" Then
            IsValid = ValidationRules.VR002(StringToCheck)
        End If
        If ValidationRuleName = "VR003" Then
            IsValid = ValidationRules.VR003(StringToCheck)
        End If
        If ValidationRuleName = "VR004" Then
            IsValid = ValidationRules.VR004(StringToCheck)
        End If
        If ValidationRuleName = "VR005" Then
            IsValid = ValidationRules.VR005(StringToCheck)
        End If
        If ValidationRuleName = "VR006" Then
            IsValid = ValidationRules.VR006(StringToCheck)
        End If
        If ValidationRuleName = "VR007" Then
            IsValid = ValidationRules.VR007(StringToCheck)
        End If
        If ValidationRuleName = "VR008" Then
            IsValid = ValidationRules.VR008(StringToCheck)
        End If
        If ValidationRuleName = "VR009" Then
            IsValid = ValidationRules.VR009(StringToCheck)
        End If
        If ValidationRuleName = "VR010" Then
            IsValid = ValidationRules.VR010(StringToCheck)
        End If
        If ValidationRuleName = "VR011" Then
            IsValid = ValidationRules.VR011(StringToCheck)
        End If
        If ValidationRuleName = "VR012" Then
            IsValid = ValidationRules.VR012(StringToCheck)
        End If
        If ValidationRuleName = "VR013" Then
            IsValid = ValidationRules.VR013(StringToCheck)
        End If
        If ValidationRuleName = "VR014" Then
            IsValid = ValidationRules.VR014(StringToCheck)
        End If
        If ValidationRuleName = "VR015" Then
            IsValid = ValidationRules.VR015(StringToCheck)
        End If
        If ValidationRuleName = "VR016" Then
            IsValid = ValidationRules.VR016(StringToCheck)
        End If
        If ValidationRuleName = "VR017" Then
            IsValid = ValidationRules.VR017(StringToCheck)
        End If
        If ValidationRuleName = "VR018" Then
            IsValid = ValidationRules.VR018(StringToCheck)
        End If
        If ValidationRuleName = "VR019" Then
            IsValid = ValidationRules.VR019(StringToCheck)
        End If
        If ValidationRuleName = "VR020" Then
            IsValid = ValidationRules.VR020(StringToCheck)
        End If
        If ValidationRuleName = "VR021" Then
            IsValid = ValidationRules.VR021(StringToCheck)
        End If
        If ValidationRuleName = "VR022" Then
            IsValid = ValidationRules.VR022(StringToCheck)
        End If
        If ValidationRuleName = "VR023" Then
            IsValid = ValidationRules.VR023(StringToCheck)
        End If
        If ValidationRuleName = "VR024" Then
            IsValid = ValidationRules.VR024(StringToCheck)
        End If
        If ValidationRuleName = "VR025" Then
            IsValid = ValidationRules.VR025(StringToCheck)
        End If
        If ValidationRuleName = "VR026" Then
            IsValid = ValidationRules.VR026(StringToCheck)
        End If
        If ValidationRuleName = "VR027" Then
            IsValid = ValidationRules.VR027(StringToCheck)
        End If
        If ValidationRuleName = "VR028" Then
            IsValid = ValidationRules.VR028(StringToCheck)
        End If
        If ValidationRuleName = "VR029" Then
            IsValid = ValidationRules.VR029(StringToCheck)
        End If
        If ValidationRuleName = "VR030" Then
            IsValid = ValidationRules.VR030(StringToCheck)
        End If
        If ValidationRuleName = "VR031" Then
            IsValid = ValidationRules.VR031(StringToCheck)
        End If
        If ValidationRuleName = "VR032" Then
            IsValid = ValidationRules.VR032(StringToCheck)
        End If
        If ValidationRuleName = "VR033" Then
            IsValid = ValidationRules.VR033(StringToCheck)
        End If
        If ValidationRuleName = "VR034" Then
            IsValid = ValidationRules.VR034(StringToCheck)
        End If

        Return IsValid

    End Function

    Public Shared Function IsExists(ByVal ValidationRuleName As String) As Boolean

        Dim ValidationRuleExists As Boolean = False

        Dim ALValidationRules As New List(Of ValidationRules)
        ALValidationRules = GetAllValidationRules()

        For I As Integer = 0 To ALValidationRules.Count - 1
            If ALValidationRules(I).ValidationRuleName = ValidationRuleName Then
                ValidationRuleExists = True
                Exit For
            End If
        Next

        Return ValidationRuleExists

    End Function

End Class
