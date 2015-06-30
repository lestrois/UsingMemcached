<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="UsingMemcached.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Label ID="Label3" runat="server" Text="Server" Width="50px" />
        <asp:TextBox ID="txtServer" runat="server" Text="192.168.1.106:56789" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Key" Width="50px" />
        <asp:TextBox ID="txtkey" runat="server" Text="key1" />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Value:" Width="50px" />
        <asp:TextBox ID="txtValue" runat="server" Width="230px" Text="Test value" />
        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insert into Memcach" />
        &nbsp;<asp:Button ID="btnStats" runat="server" Text="Get Stats" OnClick="btnStats_Click" />
        <br />
        <asp:Label ID="lblStats" runat="server" Text="Stats" />
    </div>
</asp:Content>
