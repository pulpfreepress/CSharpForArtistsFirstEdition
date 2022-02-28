/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class XMLProperties {

   // private fields
   private Dictionary<String, String> _properties = null;
   private String _filename = null;
   
   // constants
   protected const String DEFAULT_PROPERTIES_FILENAME = "properties.xml";
   
   // protected constructors
   protected XMLProperties():this(DEFAULT_PROPERTIES_FILENAME){ }
   
   protected XMLProperties(String filename){
     if((filename == null) || (filename == String.Empty)){
       _filename = DEFAULT_PROPERTIES_FILENAME;
     }else {
       _filename = filename;
     }
     _properties = new Dictionary<String, String>();
     
   }
   
   /*************************************************************
          Converts _properties dictionary into List<PropertyEntry> object
          and serializes it to an xml file.
       ************************************************************/
   public void Store(String filename){
     TextWriter writer = null;
     try {
       writer = new StreamWriter(filename);
       List<PropertyEntry> entry_list = new List<PropertyEntry>();
       foreach(KeyValuePair<String, String> entry in _properties){
         PropertyEntry pe;
         pe.PropertyName = entry.Key;
         pe.Value = entry.Value;
         entry_list.Add(pe);
       }
       //remove 
       foreach(PropertyEntry entry in entry_list){
         Console.WriteLine(entry.PropertyName + ", " + entry.Value);
       }
       
       XmlSerializer serializer = new XmlSerializer(typeof(List<PropertyEntry>));
       serializer.Serialize(writer, entry_list);
     } catch(IOException ioe){
       Console.WriteLine(ioe);
     } catch(Exception ex){
       Console.WriteLine(ex);
     } finally {
       if(writer != null) writer.Close();
     }
     _filename = filename; 
   }
   
   /**************************************************************
           Stores property entries to default file
        ****************************************************************/
   public void Store(){
     this.Store(_filename);
   }
   
   /**************************************************************
           Reads the XML properties file and populates the _properties 
           dictionary. Throws an IOException if the specified filename does
           not exist.
       **************************************************************/
   public void Read(String filename ){
     
     if(!File.Exists(filename)){
       throw new IOException("Requested file does not exist!");
     }
     FileStream fs = null;
     try {
       fs = new FileStream(filename, FileMode.Open);
       XmlSerializer serializer = new XmlSerializer(typeof(List<PropertyEntry>));
       List<PropertyEntry> entry_list = (List<PropertyEntry>)serializer.Deserialize(fs);
       foreach(PropertyEntry entry in entry_list){
         _properties[entry.PropertyName] = entry.Value;
       }
     
     }catch(IOException ioe){
       Console.WriteLine(ioe);
     }catch(Exception ex){
       Console.WriteLine(ex);
     }finally{
       if(fs != null){
         fs.Close();
       }
     }
   }
   
   /****************************************************************
           Reads the default XML properties file. 
       *****************************************************************/
   public void Read(){
     this.Read(_filename);
   }
   
   /***********************************************************
           Sets a property with given key and value
       ***********************************************************/
   public void SetProperty(String key, String value){
     _properties[key] = value; // overrites old value if it already exists
   }
   
   /**********************************************************
           Gets the value of the specified property key. Will throw an exception
           if the property does not exist.
        **********************************************************/
   public String GetProperty(String key){
     return _properties[key];
   }
   


}