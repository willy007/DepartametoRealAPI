using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;

Console.WriteLine("Hello, World!");



Document.Create(document =>
{
    document.Page(page =>
    {
        page.Margin(30);

        page.Header().Row(row => { 
            //row.ConstantItem(140).Height(60).Placeholder();

            row.RelativeItem().Column(col => {
                col.Item().AlignCenter().Text("Contrato de Servicios").Bold().FontSize(14);
                col.Item().AlignCenter().Text("Nombre Del Departamento").FontSize(9);
                col.Item().AlignCenter().Text("direccion del departameno").FontSize(9);
            });
            row.RelativeItem().Column(col => {
                col.Item().Border(1).BorderColor("#38B6FF").AlignCenter().Text("Contrato de Servicios").Bold().FontSize(14);
                col.Item().Background("#38B6FF").Border(1).BorderColor("#38B6FF").AlignCenter().Text("Turismo Real").FontSize(9);
                col.Item().Border(1).BorderColor("#38B6FF").AlignCenter().Text("Rut: 11.222.333-k").FontSize(9);
            });
        });

        page.Content().PaddingVertical(10).Column(col1 => {

            col1.Item().Text("Datos del Cliente").Underline().Bold();

            col1.Item().Text(txt => { 
                txt.Span("Nombre: ").SemiBold().FontSize(10);
                txt.Span("Nombre Cliente").FontSize(10);
            });
            col1.Item().Text(txt => { 
                txt.Span("Run/Pasaprote: ").SemiBold().FontSize(10);
                txt.Span("11.222.3333-k").FontSize(10);
            });
            col1.Item().Text(txt => { 
                txt.Span("Numero: ").SemiBold().FontSize(10);
                txt.Span("+569 111 222 33").FontSize(10);
            });


            col1.Item().Table(tabla => {

                tabla.ColumnsDefinition(columnas =>
                {
                    columnas.RelativeColumn(3);
                    columnas.RelativeColumn();
                    columnas.RelativeColumn();
                });
                tabla.Header(headr => {
                    headr.Cell().Background("#38B6FF").Border(1).BorderColor("#38B6FF").AlignCenter().Text("Descripcion");
                    headr.Cell().Background("#38B6FF").Border(1).BorderColor("#38B6FF").AlignCenter().Text("Valor");
                    headr.Cell().Background("#38B6FF").Border(1).BorderColor("#38B6FF").AlignCenter().Text("Estado");
                });
            });

        });

    });
}).ShowInPreviewer();