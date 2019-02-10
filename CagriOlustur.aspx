<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CagriOlustur.aspx.cs" Inherits="IsTakipProgramı.CagriOlustur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header well" data-original-title>
                <h2><i class="icon-edit"></i>Çağrı Ekle</h2>
                <div class="box-icon">
                    <a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>
                    <a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
                    <a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>İlgili Alanları Doldurunuz</legend>
                        <div class="control-group">
                            <label class="control-label">Çağrı Sahibi</label>
                            <div class="controls">
                                <asp:Label ID="lblKullaniciAdi" runat="server" Text="" class="input-xlarge uneditable-input"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="date01">Çağrı Başlığı</label>
                            <div class="controls">
                                <asp:TextBox ID="txtBaslik" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="date01">Çağrı Detayınız</label>
                            <div class="controls">
                                <textarea class="cleditor" id="txtAciklama" rows="3" runat="server"></textarea>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="btnKaydet_Click" />
                            <asp:Label ID="lblDurum" runat="server" Text=""></asp:Label>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
        <!--/span-->
    </div>
</asp:Content>
