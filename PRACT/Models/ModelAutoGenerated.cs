using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACT.Models.Auto
{

    // REMARQUE : Le code généré peut nécessiter au moins .NET Framework 4.5 ou .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class DJ_PLAYLISTS
    {

        private DJ_PLAYLISTSPRODUCT pRODUCTField;

        private DJ_PLAYLISTSCOLLECTION cOLLECTIONField;

        private DJ_PLAYLISTSPLAYLISTS pLAYLISTSField;

        private string versionField;

        /// <remarks/>
        public DJ_PLAYLISTSPRODUCT PRODUCT
        {
            get
            {
                return this.pRODUCTField;
            }
            set
            {
                this.pRODUCTField = value;
            }
        }

        /// <remarks/>
        public DJ_PLAYLISTSCOLLECTION COLLECTION
        {
            get
            {
                return this.cOLLECTIONField;
            }
            set
            {
                this.cOLLECTIONField = value;
            }
        }

        /// <remarks/>
        public DJ_PLAYLISTSPLAYLISTS PLAYLISTS
        {
            get
            {
                return this.pLAYLISTSField;
            }
            set
            {
                this.pLAYLISTSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DJ_PLAYLISTSPRODUCT
    {

        private string nameField;

        private string versionField;

        private string companyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Company
        {
            get
            {
                return this.companyField;
            }
            set
            {
                this.companyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DJ_PLAYLISTSCOLLECTION
    {

        private DJ_PLAYLISTSCOLLECTIONTRACK[] tRACKField;

        private ushort entriesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TRACK")]
        public DJ_PLAYLISTSCOLLECTIONTRACK[] TRACK
        {
            get
            {
                return this.tRACKField;
            }
            set
            {
                this.tRACKField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort Entries
        {
            get
            {
                return this.entriesField;
            }
            set
            {
                this.entriesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DJ_PLAYLISTSCOLLECTIONTRACK
    {

        private DJ_PLAYLISTSCOLLECTIONTRACKTEMPO[] tEMPOField;

        private DJ_PLAYLISTSCOLLECTIONTRACKPOSITION_MARK[] pOSITION_MARKField;

        private ushort trackIDField;

        private string nameField;

        private string artistField;

        private string composerField;

        private string albumField;

        private string groupingField;

        private string genreField;

        private string kindField;

        private uint sizeField;

        private ushort totalTimeField;

        private byte discNumberField;

        private ushort trackNumberField;

        private ushort yearField;

        private decimal averageBpmField;

        private System.DateTime dateAddedField;

        private ushort bitRateField;

        private ushort sampleRateField;

        private string commentsField;

        private byte playCountField;

        private byte ratingField;

        private string locationField;

        private string remixerField;

        private string tonalityField;

        private string labelField;

        private string mixField;

        private string colourField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TEMPO")]
        public DJ_PLAYLISTSCOLLECTIONTRACKTEMPO[] TEMPO
        {
            get
            {
                return this.tEMPOField;
            }
            set
            {
                this.tEMPOField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("POSITION_MARK")]
        public DJ_PLAYLISTSCOLLECTIONTRACKPOSITION_MARK[] POSITION_MARK
        {
            get
            {
                return this.pOSITION_MARKField;
            }
            set
            {
                this.pOSITION_MARKField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort TrackID
        {
            get
            {
                return this.trackIDField;
            }
            set
            {
                this.trackIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Artist
        {
            get
            {
                return this.artistField;
            }
            set
            {
                this.artistField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Composer
        {
            get
            {
                return this.composerField;
            }
            set
            {
                this.composerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Album
        {
            get
            {
                return this.albumField;
            }
            set
            {
                this.albumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Grouping
        {
            get
            {
                return this.groupingField;
            }
            set
            {
                this.groupingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Genre
        {
            get
            {
                return this.genreField;
            }
            set
            {
                this.genreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Kind
        {
            get
            {
                return this.kindField;
            }
            set
            {
                this.kindField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint Size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort TotalTime
        {
            get
            {
                return this.totalTimeField;
            }
            set
            {
                this.totalTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte DiscNumber
        {
            get
            {
                return this.discNumberField;
            }
            set
            {
                this.discNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort TrackNumber
        {
            get
            {
                return this.trackNumberField;
            }
            set
            {
                this.trackNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort Year
        {
            get
            {
                return this.yearField;
            }
            set
            {
                this.yearField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal AverageBpm
        {
            get
            {
                return this.averageBpmField;
            }
            set
            {
                this.averageBpmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime DateAdded
        {
            get
            {
                return this.dateAddedField;
            }
            set
            {
                this.dateAddedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort BitRate
        {
            get
            {
                return this.bitRateField;
            }
            set
            {
                this.bitRateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort SampleRate
        {
            get
            {
                return this.sampleRateField;
            }
            set
            {
                this.sampleRateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Comments
        {
            get
            {
                return this.commentsField;
            }
            set
            {
                this.commentsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte PlayCount
        {
            get
            {
                return this.playCountField;
            }
            set
            {
                this.playCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Rating
        {
            get
            {
                return this.ratingField;
            }
            set
            {
                this.ratingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Remixer
        {
            get
            {
                return this.remixerField;
            }
            set
            {
                this.remixerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Tonality
        {
            get
            {
                return this.tonalityField;
            }
            set
            {
                this.tonalityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Mix
        {
            get
            {
                return this.mixField;
            }
            set
            {
                this.mixField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Colour
        {
            get
            {
                return this.colourField;
            }
            set
            {
                this.colourField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DJ_PLAYLISTSCOLLECTIONTRACKTEMPO
    {

        private decimal inizioField;

        private decimal bpmField;

        private string metroField;

        private byte battitoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Inizio
        {
            get
            {
                return this.inizioField;
            }
            set
            {
                this.inizioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Bpm
        {
            get
            {
                return this.bpmField;
            }
            set
            {
                this.bpmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Metro
        {
            get
            {
                return this.metroField;
            }
            set
            {
                this.metroField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Battito
        {
            get
            {
                return this.battitoField;
            }
            set
            {
                this.battitoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DJ_PLAYLISTSCOLLECTIONTRACKPOSITION_MARK
    {

        private string nameField;

        private byte typeField;

        private decimal startField;

        private sbyte numField;

        private byte redField;

        private bool redFieldSpecified;

        private byte greenField;

        private bool greenFieldSpecified;

        private byte blueField;

        private bool blueFieldSpecified;

        private decimal endField;

        private bool endFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Start
        {
            get
            {
                return this.startField;
            }
            set
            {
                this.startField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public sbyte Num
        {
            get
            {
                return this.numField;
            }
            set
            {
                this.numField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Red
        {
            get
            {
                return this.redField;
            }
            set
            {
                this.redField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RedSpecified
        {
            get
            {
                return this.redFieldSpecified;
            }
            set
            {
                this.redFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Green
        {
            get
            {
                return this.greenField;
            }
            set
            {
                this.greenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GreenSpecified
        {
            get
            {
                return this.greenFieldSpecified;
            }
            set
            {
                this.greenFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Blue
        {
            get
            {
                return this.blueField;
            }
            set
            {
                this.blueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BlueSpecified
        {
            get
            {
                return this.blueFieldSpecified;
            }
            set
            {
                this.blueFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal End
        {
            get
            {
                return this.endField;
            }
            set
            {
                this.endField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndSpecified
        {
            get
            {
                return this.endFieldSpecified;
            }
            set
            {
                this.endFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DJ_PLAYLISTSPLAYLISTS
    {

        private DJ_PLAYLISTSPLAYLISTSNODE nODEField;

        /// <remarks/>
        public DJ_PLAYLISTSPLAYLISTSNODE NODE
        {
            get
            {
                return this.nODEField;
            }
            set
            {
                this.nODEField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DJ_PLAYLISTSPLAYLISTSNODE
    {

        private DJ_PLAYLISTSPLAYLISTSNODENODE[] nODEField;

        private byte typeField;

        private string nameField;

        private byte countField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NODE")]
        public DJ_PLAYLISTSPLAYLISTSNODENODE[] NODE
        {
            get
            {
                return this.nODEField;
            }
            set
            {
                this.nODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Count
        {
            get
            {
                return this.countField;
            }
            set
            {
                this.countField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DJ_PLAYLISTSPLAYLISTSNODENODE
    {

        private DJ_PLAYLISTSPLAYLISTSNODENODENODE[] nODEField;

        private DJ_PLAYLISTSPLAYLISTSNODENODETRACK[] tRACKField;

        private string nameField;

        private byte typeField;

        private byte keyTypeField;

        private bool keyTypeFieldSpecified;

        private ushort entriesField;

        private bool entriesFieldSpecified;

        private byte countField;

        private bool countFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NODE")]
        public DJ_PLAYLISTSPLAYLISTSNODENODENODE[] NODE
        {
            get
            {
                return this.nODEField;
            }
            set
            {
                this.nODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TRACK")]
        public DJ_PLAYLISTSPLAYLISTSNODENODETRACK[] TRACK
        {
            get
            {
                return this.tRACKField;
            }
            set
            {
                this.tRACKField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte KeyType
        {
            get
            {
                return this.keyTypeField;
            }
            set
            {
                this.keyTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KeyTypeSpecified
        {
            get
            {
                return this.keyTypeFieldSpecified;
            }
            set
            {
                this.keyTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort Entries
        {
            get
            {
                return this.entriesField;
            }
            set
            {
                this.entriesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EntriesSpecified
        {
            get
            {
                return this.entriesFieldSpecified;
            }
            set
            {
                this.entriesFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Count
        {
            get
            {
                return this.countField;
            }
            set
            {
                this.countField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountSpecified
        {
            get
            {
                return this.countFieldSpecified;
            }
            set
            {
                this.countFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DJ_PLAYLISTSPLAYLISTSNODENODENODE
    {

        private DJ_PLAYLISTSPLAYLISTSNODENODENODENODE[] nODEField;

        private DJ_PLAYLISTSPLAYLISTSNODENODENODETRACK[] tRACKField;

        private string nameField;

        private byte typeField;

        private byte keyTypeField;

        private bool keyTypeFieldSpecified;

        private byte entriesField;

        private bool entriesFieldSpecified;

        private byte countField;

        private bool countFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NODE")]
        public DJ_PLAYLISTSPLAYLISTSNODENODENODENODE[] NODE
        {
            get
            {
                return this.nODEField;
            }
            set
            {
                this.nODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TRACK")]
        public DJ_PLAYLISTSPLAYLISTSNODENODENODETRACK[] TRACK
        {
            get
            {
                return this.tRACKField;
            }
            set
            {
                this.tRACKField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte KeyType
        {
            get
            {
                return this.keyTypeField;
            }
            set
            {
                this.keyTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KeyTypeSpecified
        {
            get
            {
                return this.keyTypeFieldSpecified;
            }
            set
            {
                this.keyTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Entries
        {
            get
            {
                return this.entriesField;
            }
            set
            {
                this.entriesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EntriesSpecified
        {
            get
            {
                return this.entriesFieldSpecified;
            }
            set
            {
                this.entriesFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Count
        {
            get
            {
                return this.countField;
            }
            set
            {
                this.countField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountSpecified
        {
            get
            {
                return this.countFieldSpecified;
            }
            set
            {
                this.countFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DJ_PLAYLISTSPLAYLISTSNODENODENODENODE
    {

        private DJ_PLAYLISTSPLAYLISTSNODENODENODENODETRACK[] tRACKField;

        private string nameField;

        private byte typeField;

        private byte keyTypeField;

        private byte entriesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TRACK")]
        public DJ_PLAYLISTSPLAYLISTSNODENODENODENODETRACK[] TRACK
        {
            get
            {
                return this.tRACKField;
            }
            set
            {
                this.tRACKField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte KeyType
        {
            get
            {
                return this.keyTypeField;
            }
            set
            {
                this.keyTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Entries
        {
            get
            {
                return this.entriesField;
            }
            set
            {
                this.entriesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DJ_PLAYLISTSPLAYLISTSNODENODENODENODETRACK
    {

        private ushort keyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DJ_PLAYLISTSPLAYLISTSNODENODENODETRACK
    {

        private ushort keyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DJ_PLAYLISTSPLAYLISTSNODENODETRACK
    {

        private ushort keyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
    }


}
