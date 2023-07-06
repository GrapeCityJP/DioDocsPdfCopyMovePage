// See https://aka.ms/new-console-template for more information

using GrapeCity.Documents.Pdf;

Console.WriteLine("PDFのページをコピー");

var fs = new FileStream("diodocs_a4_full.pdf", FileMode.Open);
var doc1 = new GcPdfDocument();
doc1.Load(fs);

// 1ページ目をコピー
doc1.Pages.ClonePage(0, 0, true, true);

doc1.Save("ClonePage.pdf");
    
Console.WriteLine("PDFのページを移動");

var doc2 = new GcPdfDocument();
doc2.Load(fs);

// 1ページ目を3ページ目に移動
doc2.Pages.Move(0, 2);

doc2.Save("MovePage.pdf");

Console.WriteLine("番外編：PDFのページごとに分割");

var doc3 = new GcPdfDocument();
doc3.Load(fs);

// 結合オプション
var options = new MergeDocumentOptions();

// 1ページずつ分割する
for (int i = 1; i <= doc3.Pages.Count; i++)
{
    options.PagesRange = new GrapeCity.Documents.Common.OutputRange(i, i);

    var separateDoc = new GcPdfDocument();
    separateDoc.MergeWithDocument(doc3, options);
    separateDoc.Save(String.Format("SplitPage{0}.pdf", i));
}