<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Restraunt.aspx.cs" Inherits="Food_Menu.Restraunt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Name: </td>
            <td><asp:TextBox ID="textname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Select Food: </td>
            <td><asp:DropDownList ID="ddlft" runat="server" OnSelectedIndexChanged="ddlft_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Category: </td>
            <td><asp:DropDownList ID="ddlcat" runat="server"></asp:DropDownList></td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Button ID="btninsert" runat="server" Text="INSERT" OnClick="btninsert_Click" /></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:GridView ID="gvresturant" runat="server" AutoGenerateColumns="False" OnRowCommand="gvresturant_RowCommand" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <%# Eval("rid") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%# Eval("name") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Food">
                            <ItemTemplate>
                                <%# Eval("fname") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <%# Eval("ftname") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="dlt" CommandArgument='<%# Eval("rid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="edt" CommandArgument='<%# Eval("rid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
