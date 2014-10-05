<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Info.aspx.cs" Inherits="Committee_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="divPanel notop page-content container-fluid">

        <h1 runat="server" id="CommitteeName">Committee</h1>

        <div class="row">

            <!--Edit Sidebar Content here-->
            <div class="col-md-3">
                <h3>Description</h3>
                <p runat="server" id="CommitteeDescription"></p>
                
                <asp:Repeater runat="server" ID="ChairPersons">
                    <HeaderTemplate><h3>Chair Persons</h3></HeaderTemplate>
                    <ItemTemplate>
                        <p><address>
                            <strong><%#DataBinder.Eval(Container.DataItem, "Member.Name")%></strong><br />
                            <abbr title="Phone">P:</abbr> 
                                <a href="<%#String.Format("tel:+{0}", DataBinder.Eval(Container.DataItem, "Member.Phone"))%>"><%#DataBinder.Eval(Container.DataItem, "Member.Phone")%></a><br />
                            <a href="mailto:<%#DataBinder.Eval(Container.DataItem, "Member.Email")%>"><%#DataBinder.Eval(Container.DataItem, "Member.Email")%></a>
                           </address>
                        </p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <!--/End Sidebar Content -->

            <!--Edit Main Content Area here-->
            <div class="col-md-9" id="divMain">
                <asp:FileUpload runat="server" CssClass="form-control" ID="FileUpload" /><br />
                <asp:Button runat="server" CssClass="form-control" Text="Upload" OnClick="OnFileUpload" /><br />
                <asp:Label runat="server" CssClass="form-control" ID="Label"></asp:Label>
                <h2>Two Column (left-hand sidebar)</h2>
                <hr>
                <p>Aliquam a tellus quam. Phasellus sit amet bibendum nunc. Donec lobortis nulla diam, a laoreet nisi rhoncus vitae. Suspendisse tincidunt, nulla sed convallis consectetur, diam enim ultricies nulla, a luctus odio nisi in ligula. Aenean ornare rhoncus fermentum. Suspendisse et enim in nibh dictum blandit et id nisi. Duis mollis, libero id venenatis viverra, metus lacus placerat turpis, at semper orci odio id lectus. Proin fringilla quam porttitor est mattis, id aliquam est laoreet. Nulla congue urna nisi, eu commodo dolor aliquet eget. Donec ullamcorper diam quis porttitor convallis. Aliquam erat volutpat. Phasellus pulvinar sagittis nunc et adipiscing.</p>
                <p>Duis facilisis tellus ante, eu sodales neque ornare vitae. Pellentesque laoreet velit diam, quis tempor est fringilla sed. Curabitur in ullamcorper lectus, et gravida mauris. Suspendisse tristique euismod metus, quis facilisis lectus cursus faucibus. Nulla sed leo sed tellus egestas mattis sed id libero. Aenean at scelerisque augue. Phasellus at sem porttitor, auctor metus pharetra, lacinia sapien.</p>
                <p>Etiam enim dui, dictum vitae lobortis quis, placerat feugiat leo. Sed commodo elit orci, non tincidunt velit suscipit in. Nulla facilisi. Praesent vel eros tristique, lobortis orci vitae, interdum quam. In hac habitasse platea dictumst. Praesent lobortis iaculis ante, at laoreet est pulvinar vel. Cras vulputate tempus nulla eget venenatis. Suspendisse magna lacus, tincidunt nec pulvinar sit amet, semper quis neque. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Cras vehicula volutpat enim, id vehicula dolor porttitor in. Nam vehicula velit erat, eu consectetur elit luctus ut. Aliquam ac convallis enim, et venenatis dui. Maecenas et leo metus. Etiam diam ante, lacinia vitae orci vel, dignissim vestibulum tortor. Aliquam elit sapien, pellentesque eu consectetur et, tempor vitae nisl.</p>
                <p>
                    Donec arcu nisi, euismod vitae facilisis id, pulvinar eget tortor. Nunc lobortis ultrices pellentesque. Sed sollicitudin dapibus erat a interdum. Cras massa mauris, rutrum vel nisi non, malesuada lobortis velit. Fusce eu tellus justo. Donec dictum, purus at adipiscing rhoncus, risus libero bibendum ipsum, mollis vestibulum arcu arcu eget elit. In tempor laoreet ultricies. 
					Maecenas lacus neque, fermentum in blandit a, mollis in libero. Vivamus ornare eros quis arcu cursus, at luctus nisi accumsan.
                </p>
                <div class="table-responsive">
                <table class="table table-condensed table-striped">
                    <thead>
                        <tr>
                            <td>Attachment</td>
                            <td></td>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="AttachedFiles">
                            <ItemTemplate>
                            <tr>
                                <td><%# Container.DataItem as string %></td>
                            </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                </div>
            </div>

            <!--/End Main Content Area here-->


        </div>

        <div id="footerInnerSeparator"></div>
    </div>

</asp:Content>

