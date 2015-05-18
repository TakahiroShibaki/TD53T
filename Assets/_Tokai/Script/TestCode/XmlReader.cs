using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("Setting")]
public class SettingXml
{
	[XmlElement("GAME_MODE")]
	public string _game_mode{ get; set; }

	[XmlElement("Stage")]
	public int _stage_number{ get; set; }

	[XmlElement("Enemy_Map")]
	public List<string> _enemy_map{ get; set; }
}

public class XmlReader
{
	private const string _file = "./setting.xml";

	public bool Load( ref SettingXml setting )
	{
		if( File.Exists( _file ) != false )
		{
			StreamReader sr = new StreamReader( _file );
			XmlSerializer serializer = new XmlSerializer( typeof( SettingXml ) );
			setting = ( SettingXml )serializer.Deserialize( sr );
			sr.Close();
			return true;
		}
		return false;
	}
}
