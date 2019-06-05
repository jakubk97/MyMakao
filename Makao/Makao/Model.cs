using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Makao
{
    class Model
    {
        //#region Functions
        //public string[] LoadStartDirectory()
        //{
        //    try
        //    {
        //        if (Directory.Exists(Environment.CurrentDirectory + @"\Testy"))
        //        {
        //            List<string> tmp = new List<string>();
        //            foreach (var d in Directory.GetFiles(Environment.CurrentDirectory + @"\Testy", "*.xml"))
        //                tmp.Add(Path.GetFileName(d));
        //            return tmp.ToArray();
        //        }
        //        else
        //        {
        //            Directory.CreateDirectory(Environment.CurrentDirectory + @"\Testy");
        //            List<string> tmp = new List<string>();
        //            return tmp.ToArray();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        List<string> tmp = new List<string>();
        //        return tmp.ToArray();
        //    }
        //}

        //public string[] LoadTest(string name)
        //{
        //    try
        //    {
        //        //czytanie xml-a
        //        XmlDocument doca = new XmlDocument();
        //        string filenamea = Environment.CurrentDirectory + @"\Testy\" + name;
        //        int it = 1;
        //        doca.Load(filenamea);
        //        XmlNodeList nodesa = doca.SelectNodes("content/task");
        //        List<string> tmp = new List<string>();
        //        foreach (XmlNode node in nodesa)
        //        {
        //            tmp.Add("Question " + it);
        //            it++;
        //        }

        //        return tmp.ToArray();
        //    }
        //    catch (Exception ex)
        //    {
        //        List<string> tmp = new List<string>();
        //        return tmp.ToArray();
        //    }
        //}

        //public void Delete(string name, int index)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        string filename = Environment.CurrentDirectory + @"\Testy\" + name + ".xml";
        //        doc.Load(filename);
        //        string nodess = doc.ChildNodes.ToString();
        //        XmlNodeList nodes = doc.SelectNodes("//task");
        //        nodes[index].ParentNode.RemoveChild(nodes[index]);
        //        doc.Save(filename);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //public void Save(string name, string question, string ans1, string ans2, string ans3, string ans4,
        //    string points, string cb1, string cb2, string cb3, string cb4, int index)
        //{
        //    try
        //    {
        //        #region DeleteOld
        //        XmlDocument doc = new XmlDocument();
        //        string filename = Environment.CurrentDirectory + @"\Testy\" + name + ".xml";
        //        doc.Load(filename);
        //        string nodess = doc.ChildNodes.ToString();
        //        XmlNodeList nodes = doc.SelectNodes("//task");
        //        nodes[index].ParentNode.RemoveChild(nodes[index]);
        //        #endregion

        //        #region createTask
        //        //create node and add value
        //        XmlNode node = doc.CreateNode(XmlNodeType.Element, "task", null);
        //        XmlAttribute attr = doc.CreateAttribute("points");
        //        attr.Value = points;
        //        node.Attributes.SetNamedItem(attr);

        //        //create question node
        //        XmlNode nodeQuestion = doc.CreateElement("question");
        //        //add value for it
        //        nodeQuestion.InnerText = question;
        //        #endregion

        //        #region ans1
        //        //create ans1 node
        //        XmlNode nodeAns1 = doc.CreateElement("answer");
        //        nodeAns1.InnerText = ans1;
        //        XmlAttribute at1 = doc.CreateAttribute("correct");
        //        if (cb1 == "Checked")
        //        {
        //            at1.Value = "true";
        //        }
        //        else
        //        {
        //            at1.Value = "false";
        //        }
        //        nodeAns1.Attributes.SetNamedItem(at1);
        //        #endregion
        //        #region ans2
        //        //create ans2 node
        //        XmlNode nodeAns2 = doc.CreateElement("answer");
        //        nodeAns2.InnerText = ans2;
        //        XmlAttribute at2 = doc.CreateAttribute("correct");
        //        if (cb2 == "Checked")
        //        {
        //            at2.Value = "true";
        //        }
        //        else
        //        {
        //            at2.Value = "false";
        //        }
        //        nodeAns2.Attributes.SetNamedItem(at2);
        //        #endregion
        //        #region ans3
        //        //create ans3 node
        //        XmlNode nodeAns3 = doc.CreateElement("answer");
        //        nodeAns3.InnerText = ans3;
        //        XmlAttribute at3 = doc.CreateAttribute("correct");
        //        if (cb3 == "Checked")
        //        {
        //            at3.Value = "true";
        //        }
        //        else
        //        {
        //            at3.Value = "false";
        //        }
        //        nodeAns3.Attributes.SetNamedItem(at3);
        //        #endregion
        //        #region ans4
        //        //create ans4 node
        //        XmlNode nodeAns4 = doc.CreateElement("answer");
        //        nodeAns4.InnerText = ans4;
        //        XmlAttribute at4 = doc.CreateAttribute("correct");
        //        if (cb4 == "Checked")
        //        {
        //            at4.Value = "true";
        //        }
        //        else
        //        {
        //            at4.Value = "false";
        //        }
        //        nodeAns4.Attributes.SetNamedItem(at4);
        //        #endregion

        //        #region AddChildCloseDoc
        //        //add to parent node
        //        node.AppendChild(nodeQuestion);
        //        node.AppendChild(nodeAns1);
        //        node.AppendChild(nodeAns2);
        //        node.AppendChild(nodeAns3);
        //        node.AppendChild(nodeAns4);
        //        //add to elements collection
        //        doc.DocumentElement.AppendChild(node);

        //        //save back
        //        doc.Save(filename);
        //        #endregion
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //public void Add(string name, string question, string ans1, string ans2, string ans3, string ans4,
        //    string points, string cb1, string cb2, string cb3, string cb4)
        //{
        //    try
        //    {

        //        if (!File.Exists(Environment.CurrentDirectory + @"\Testy\" + name + ".xml"))
        //        {
        //            #region createXFile
        //            XDocument xDoc = new XDocument(
        //             new XDeclaration("1.0", "utf-8", null),
        //             new XElement("content",
        //                 new XElement("test",
        //               new XAttribute("evaluation", "normal"),
        //                new XAttribute("mark-5", "0.9"),
        //                 new XAttribute("mark-4.5", "0.8"),
        //                  new XAttribute("mark-4", "0.7"),
        //                   new XAttribute("mark-3.5", "0.6"),
        //                    new XAttribute("mark-3", "0.5"),
        //                     new XAttribute("mark-2.5", "none"),
        //                      new XAttribute("mark-2", "none"), name)
        //               ));
        //            xDoc.Save(Environment.CurrentDirectory + @"\Testy\" + name + ".xml");
        //            #endregion
        //            #region createTask
        //            //create task
        //            string filename = Environment.CurrentDirectory + @"\Testy\" + name + ".xml";

        //            //create new instance of XmlDocument
        //            XmlDocument doc = new XmlDocument();
        //            //load from file
        //            doc.Load(filename);
        //            //create node and add value
        //            XmlNode node = doc.CreateNode(XmlNodeType.Element, "task", null);
        //            XmlAttribute attr = doc.CreateAttribute("points");
        //            attr.Value = points;
        //            node.Attributes.SetNamedItem(attr);

        //            //create question node
        //            XmlNode nodeQuestion = doc.CreateElement("question");
        //            //add value for it
        //            nodeQuestion.InnerText = question;
        //            #endregion

        //            #region ans1
        //            //create ans1 node
        //            XmlNode nodeAns1 = doc.CreateElement("answer");
        //            nodeAns1.InnerText = ans1;
        //            XmlAttribute at1 = doc.CreateAttribute("correct");
        //            if (cb1 == "Checked")
        //            {
        //                at1.Value = "true";
        //            }
        //            else
        //            {
        //                at1.Value = "false";
        //            }
        //            nodeAns1.Attributes.SetNamedItem(at1);
        //            #endregion
        //            #region ans2
        //            //create ans2 node
        //            XmlNode nodeAns2 = doc.CreateElement("answer");
        //            nodeAns2.InnerText = ans2;
        //            XmlAttribute at2 = doc.CreateAttribute("correct");
        //            if (cb2 == "Checked")
        //            {
        //                at2.Value = "true";
        //            }
        //            else
        //            {
        //                at2.Value = "false";
        //            }
        //            nodeAns2.Attributes.SetNamedItem(at2);
        //            #endregion
        //            #region ans3
        //            //create ans3 node
        //            XmlNode nodeAns3 = doc.CreateElement("answer");
        //            nodeAns3.InnerText = ans3;
        //            XmlAttribute at3 = doc.CreateAttribute("correct");
        //            if (cb3 == "Checked")
        //            {
        //                at3.Value = "true";
        //            }
        //            else
        //            {
        //                at3.Value = "false";
        //            }
        //            nodeAns3.Attributes.SetNamedItem(at3);
        //            #endregion
        //            #region ans4
        //            //create ans4 node
        //            XmlNode nodeAns4 = doc.CreateElement("answer");
        //            nodeAns4.InnerText = ans4;
        //            XmlAttribute at4 = doc.CreateAttribute("correct");
        //            if (cb4 == "Checked")
        //            {
        //                at4.Value = "true";
        //            }
        //            else
        //            {
        //                at4.Value = "false";
        //            }
        //            nodeAns4.Attributes.SetNamedItem(at4);
        //            #endregion

        //            #region AddChildCloseDoc
        //            //add to parent node
        //            node.AppendChild(nodeQuestion);
        //            node.AppendChild(nodeAns1);
        //            node.AppendChild(nodeAns2);
        //            node.AppendChild(nodeAns3);
        //            node.AppendChild(nodeAns4);
        //            //add to elements collection
        //            doc.DocumentElement.AppendChild(node);

        //            //save back
        //            doc.Save(filename);
        //            #endregion
        //        }
        //        else
        //        {
        //            #region createTask
        //            //create task
        //            string filename = Environment.CurrentDirectory + @"\Testy\" + name + ".xml";

        //            //create new instance of XmlDocument
        //            XmlDocument doc = new XmlDocument();
        //            //load from file
        //            doc.Load(filename);
        //            //create node and add value
        //            XmlNode node = doc.CreateNode(XmlNodeType.Element, "task", null);
        //            XmlAttribute attr = doc.CreateAttribute("points");
        //            attr.Value = points;
        //            node.Attributes.SetNamedItem(attr);

        //            //create question node
        //            XmlNode nodeQuestion = doc.CreateElement("question");
        //            //add value for it
        //            nodeQuestion.InnerText = question;
        //            #endregion

        //            #region ans1
        //            //create ans1 node
        //            XmlNode nodeAns1 = doc.CreateElement("answer");
        //            nodeAns1.InnerText = ans1;
        //            XmlAttribute at1 = doc.CreateAttribute("correct");
        //            if (cb1 == "Checked")
        //            {
        //                at1.Value = "true";
        //            }
        //            else
        //            {
        //                at1.Value = "false";
        //            }
        //            nodeAns1.Attributes.SetNamedItem(at1);
        //            #endregion
        //            #region ans2
        //            //create ans2 node
        //            XmlNode nodeAns2 = doc.CreateElement("answer");
        //            nodeAns2.InnerText = ans2;
        //            XmlAttribute at2 = doc.CreateAttribute("correct");
        //            if (cb2 == "Checked")
        //            {
        //                at2.Value = "true";
        //            }
        //            else
        //            {
        //                at2.Value = "false";
        //            }
        //            nodeAns2.Attributes.SetNamedItem(at2);
        //            #endregion
        //            #region ans3
        //            //create ans3 node
        //            XmlNode nodeAns3 = doc.CreateElement("answer");
        //            nodeAns3.InnerText = ans3;
        //            XmlAttribute at3 = doc.CreateAttribute("correct");
        //            if (cb3 == "Checked")
        //            {
        //                at3.Value = "true";
        //            }
        //            else
        //            {
        //                at3.Value = "false";
        //            }
        //            nodeAns3.Attributes.SetNamedItem(at3);
        //            #endregion
        //            #region ans4
        //            //create ans4 node
        //            XmlNode nodeAns4 = doc.CreateElement("answer");
        //            nodeAns4.InnerText = ans4;
        //            XmlAttribute at4 = doc.CreateAttribute("correct");
        //            if (cb4 == "Checked")
        //            {
        //                at4.Value = "true";
        //            }
        //            else
        //            {
        //                at4.Value = "false";
        //            }
        //            nodeAns4.Attributes.SetNamedItem(at4);
        //            #endregion

        //            #region AddChildCloseDoc
        //            //add to parent node
        //            node.AppendChild(nodeQuestion);
        //            node.AppendChild(nodeAns1);
        //            node.AppendChild(nodeAns2);
        //            node.AppendChild(nodeAns3);
        //            node.AppendChild(nodeAns4);
        //            //add to elements collection
        //            doc.DocumentElement.AppendChild(node);

        //            //save back
        //            doc.Save(filename);
        //            #endregion
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public string[] LoadQuestion(string name, int index)
        //{
        //    try
        //    {
        //        //czytanie xml-a
        //        XmlDocument doca = new XmlDocument();
        //        string filenamea = Environment.CurrentDirectory + @"\Testy\" + name;
        //        int it = 0;
        //        doca.Load(filenamea);
        //        XmlNodeList nodesa = doca.SelectNodes("content/task");
        //        List<string> tmp = new List<string>();
        //        foreach (XmlNode node in nodesa)
        //        {
        //            if (it == index)
        //            {
        //                tmp.Add(node.Attributes["points"].Value);
        //                XmlNodeList addresses = node.SelectNodes("question");
        //                foreach (XmlNode address in addresses)
        //                {
        //                    tmp.Add(address.InnerText);
        //                }
        //                XmlNodeList prices = node.SelectNodes("answer");
        //                foreach (XmlNode price in prices)
        //                {
        //                    tmp.Add(price.InnerText);
        //                    tmp.Add(price.Attributes["correct"].Value);
        //                }
        //                it++;
        //            }
        //            else
        //                it++;
        //        }

        //        return tmp.ToArray();
        //    }
        //    catch (Exception ex)
        //    {
        //        List<string> tmp = new List<string>();
        //        return tmp.ToArray();
        //    }
        //}
        //#endregion
    }
}
