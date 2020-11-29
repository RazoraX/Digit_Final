using System.IO;
using GemBox.Document;
using GemBox.Pdf.Forms;
using GemBox.Pdf;
using DidiSoft.Pgp;
using RazorPageNewTest.Models;

namespace RazorPageNewTest
{
    public class CryptoBack
    {
        public class CryptoStruct
        {

            public string sertificate_path = Directory.GetCurrentDirectory()+"\\Sertif\\Natus_est_Scientia2_0.pfx";
            public string img_path = Directory.GetCurrentDirectory() + "\\Sertif\\ecp.png";
            public string password = "0000";
        }

        public void ConvertCrypt_DOCX_2_PDFA(string docx_file)
        {
            CryptoStruct crypter = new CryptoStruct();
            GemBox.Document.ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            GemBox.Pdf.ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            var document = DocumentModel.Load(docx_file);
            var signature = new Picture(document, crypter.img_path);
            var lastSection = document.Sections[document.Sections.Count - 1];
            lastSection.Blocks.Add(new Paragraph(document, signature));
            var options = new GemBox.Document.PdfSaveOptions()
            {
                DigitalSignature =
                {
                    CertificatePath = crypter.sertificate_path,
                    CertificatePassword = crypter.password,
                    Signature = signature,
                    IsAdvancedElectronicSignature = false,
                },
                ConformanceLevel = PdfConformanceLevel.PdfA1a
            };
            document.Save(Path.ChangeExtension(docx_file, ".pdf"), options);
            using (var pdfDocument = GemBox.Pdf.PdfDocument.Load(Path.ChangeExtension(docx_file, ".pdf")))
            {
                var signatureField = (PdfSignatureField)pdfDocument.Form.Fields[0];
                pdfDocument.SecurityStore.AddValidationInfo(signatureField.Value);
                pdfDocument.Save();
            }
        }
        public void Generate_Sig_Key(string docx_file)
        {
            CryptoStruct crypter = new CryptoStruct();
            PGPLib pgp = new PGPLib();
            bool asciiArmor = true;
            pgp.DetachedSignFile(docx_file, crypter.sertificate_path, crypter.password, Path.ChangeExtension(docx_file, ".pdf")+".sig", asciiArmor);
        }
        public string Validate_After_All(string pdf_file)
        {
            int restores = 0;
            string rest = "";
            using (var document_val = PdfDocument.Load(pdf_file))
            {
                foreach (var field in document_val.Form.Fields)
                {
                    if (field.FieldType == PdfFieldType.Signature)
                    {
                        var signatureField = (PdfSignatureField)field;

                        var signature_val = signatureField.Value;

                        if (signature_val != null)
                        {
                            var signatureValidationResult = signature_val.Validate();

                            if (signatureValidationResult.IsValid)
                            {
                                //return "Ваш документ не был изменён: Signature '{0}' is VALID, signed by '{1}'. " + signatureField.Name + signature_val.Content.SignerCertificate.SubjectCommonName + "The document has not been modified since this signature was applied.";
                            }
                            else
                            {
                                restores++;
                                rest += "Signature '{0}' is INVALID." + signatureField.Name;
                                //return "Ваш документ был изменён: Signature '{0}' is INVALID. " + signatureField.Name + "The document has been altered or corrupted since the signature was applied.";
                            }
                        }
                    }
                }
            }
            if (restores != 0) return "Ваш документ был изменён :" + rest + "The document has been altered or corrupted since the signature was applied.";
            else return "Ваш документ не был изменён: The document has not been modified since this signature was applied.";
        }
    }
}