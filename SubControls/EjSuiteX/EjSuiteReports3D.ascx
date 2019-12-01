<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteReports3D.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteReports3D" %>
<%@ Register Assembly="dotnetCHARTING" Namespace="dotnetCHARTING" TagPrefix="dotnetCHARTING" %>

<dotnetCHARTING:Chart ID="Chart1" runat="server"
    GanttCompleteHatchStyle="ForwardDiagonal">
    <JS>
        <Buttons>
            <Background ShadingEffectMode="Default" Color="220, 220, 220"></Background>

            <Foreground Color="White"></Foreground>

            <Outline Color="123, 123, 123"></Outline>

            <IconStrokeLine Color="123, 123, 123"></IconStrokeLine>

            <ForegroundHover Color="White"></ForegroundHover>

            <OutlineHover Color="80, 80, 80"></OutlineHover>

            <IconStrokeLineHover Color="108, 106, 133"></IconStrokeLineHover>
        </Buttons>
    </JS>

    <Box DynamicSize="True" Size="639, 479">
        <Header>
            <Label Alignment="Center" Font="Tahoma, 7.5pt, style=Bold"></Label>
            <Background ShadingEffectMode="Default" />
        </Header>

        <HeaderLabel Alignment="Center" Font="Tahoma, 7.5pt, style=Bold"></HeaderLabel>

        <HeaderBackground ShadingEffectMode="Default" />

        <Background Color="" ShadingEffectMode="Default"></Background>
        <Shadow Depth="1" ExpandBy="2" Visible="False" />
    </Box>

    <SmartForecast Start="" Unit="None"></SmartForecast>

    <DefaultElement>
        <DefaultSubValue Visible="True"></DefaultSubValue>
    </DefaultElement>

    <DefaultLegendBox Padding="4">
        <HeaderEntry Visible="False"></HeaderEntry>

        <Header>
            <Label Alignment="Center" Font="Tahoma, 7.5pt, style=Bold"></Label>

            <Background ShadingEffectMode="Default"></Background>
        </Header>

        <HeaderLabel Alignment="Center" Font="Tahoma, 7.5pt, style=Bold"></HeaderLabel>

        <HeaderBackground ShadingEffectMode="Default"></HeaderBackground>

        <Shadow ExpandBy="2"></Shadow>
    </DefaultLegendBox>

    <DefaultTitleBox>
        <Header>
            <Label Alignment="Center" Font="Tahoma, 7.5pt, style=Bold"></Label>

            <Background ShadingEffectMode="Default"></Background>
        </Header>

        <HeaderLabel Alignment="Center" Font="Tahoma, 7.5pt, style=Bold"></HeaderLabel>

        <HeaderBackground ShadingEffectMode="Default"></HeaderBackground>

        <Shadow ExpandBy="2"></Shadow>
    </DefaultTitleBox>

    <ChartArea StartDateOfYear="" CornerTopLeft="Square">
        <DefaultElement>
            <DefaultSubValue Visible="True">
                <Line Length="4" />
            </DefaultSubValue>
        </DefaultElement>

        <YAxis>
            <ScaleBreakLine Color="Gray"></ScaleBreakLine>

            <TimeScaleLabels MaximumRangeRows="4"></TimeScaleLabels>

            <MinorTimeIntervalAdvanced Start="" Unit="None"></MinorTimeIntervalAdvanced>

            <ZeroTick>
                <Line Length="3"></Line>
            </ZeroTick>

            <DefaultTick>
                <Line Length="3"></Line>

                <Label Text="%Value"></Label>
            </DefaultTick>

            <TimeIntervalAdvanced Start="" Unit="Months"></TimeIntervalAdvanced>

            <AlternateGridBackground Color=""></AlternateGridBackground>

            <Label Alignment="Center" Font="Tahoma, 9pt, style=Bold"></Label>
        </YAxis>

        <XAxis>
            <ScaleBreakLine Color="Gray"></ScaleBreakLine>

            <TimeScaleLabels MaximumRangeRows="4"></TimeScaleLabels>

            <MinorTimeIntervalAdvanced Start="" Unit="None"></MinorTimeIntervalAdvanced>

            <ZeroTick>
                <Line Length="3"></Line>
            </ZeroTick>

            <DefaultTick>
                <Line Length="3"></Line>

                <Label Text="%Value"></Label>
            </DefaultTick>

            <TimeIntervalAdvanced Start="" Unit="Months"></TimeIntervalAdvanced>

            <Label Alignment="Center" Font="Tahoma, 9pt, style=Bold"></Label>
        </XAxis>

        <Shadow ExpandBy="2" Depth="1"></Shadow>

        <TitleBox Position="Left">
            <Header>
                <Label Alignment="Center" Font="Tahoma, 7.5pt, style=Bold"></Label>

                <Background ShadingEffectMode="Default"></Background>
            </Header>

            <HeaderLabel Alignment="Center" Font="Tahoma, 7.5pt, style=Bold"></HeaderLabel>

            <HeaderBackground ShadingEffectMode="Default"></HeaderBackground>

            <Label LineAlignment="Center"></Label>

            <Shadow ExpandBy="2"></Shadow>
        </TitleBox>

        <LegendBox Padding="4" Position="Top" CornerBottomRight="Cut">
            <LabelStyle Font="Trebuchet MS, 8pt"></LabelStyle>

            <DefaultEntry>
                <LabelStyle Font="Trebuchet MS, 8pt"></LabelStyle>
            </DefaultEntry>

            <HeaderEntry Name="Name" Value="Value" Visible="False" SortOrder="-1"></HeaderEntry>

            <Header>
                <Label Alignment="Center" Font="Tahoma, 7.5pt, style=Bold"></Label>

                <Background ShadingEffectMode="Default"></Background>
            </Header>

            <HeaderLabel Alignment="Center" Font="Tahoma, 7.5pt, style=Bold"></HeaderLabel>

            <HeaderBackground ShadingEffectMode="Default"></HeaderBackground>

            <Line Color="Black"></Line>

            <Shadow ExpandBy="2"></Shadow>
        </LegendBox>
    </ChartArea>

    <TitleBox Position="Left">
        <Header>
            <Label Alignment="Center" Font="Tahoma, 7.5pt, style=Bold"></Label>

            <Background ShadingEffectMode="Default"></Background>
        </Header>

        <HeaderLabel Alignment="Center" Font="Tahoma, 7.5pt, style=Bold"></HeaderLabel>

        <HeaderBackground ShadingEffectMode="Default"></HeaderBackground>

        <Label LineAlignment="Center"></Label>

        <Shadow ExpandBy="2"></Shadow>
    </TitleBox>

    <DefaultShadow ExpandBy="2" Color="50, 50, 50, 50"></DefaultShadow>
</dotnetCHARTING:Chart>

