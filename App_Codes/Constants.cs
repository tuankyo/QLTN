using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections;

namespace Man
{
    public class Constants
    {
        public static double MinPayment = 5000;
        public static string[] Areas = {"","北海道","青森県","岩手県","宮城県","秋田県","山形県","福島県","茨城県","栃木県", 
                                    "群馬県","埼玉県","千葉県","東京都","神奈川県","新潟県","富山県","石川県","福井県", 
                                    "山梨県","長野県","岐阜県","静岡県","愛知県","三重県","滋賀県","京都府","大阪府",
                                    "兵庫県","奈良県","和歌山県","鳥取県","島根県","岡山県","広島県","山口県","徳島県",
                                    "香川県","愛媛県","高知県","福岡県","佐賀県","長崎県","熊本県","大分県","宮崎県","鹿児島県","沖縄県"};
        public static string[] Yomi = { "", "ｱ", "ｶ", "ｻ", "ﾀ", "ﾅ", "ﾊ", "ﾏ", "ﾔ", "ﾗ", "ﾜ", "ﾝ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public static string[] PaymentType = { "", "曲線", "定率", "定額" };

        public static string[] SynLog = { "", "success", "unsuccess" };
        public static string[] SynTable = { "", "Song", "Artist", "Album", "Label", "Contractor", "Genre", "Lyric", "MusicStyle" };

        public static string[] CollectCode = { "", "Y", "Ｘ", "1" };
        public static string[] CollectCodeVal = { "", "Y:著作権CD変更発生", "Ｘ:著作権CDは修正される", "1:著作権CDは正しい" };

        public static string[] IVTType = { "", "I", "V", "T" };
        public static string[] IVTTypeVal = { "", "\"I\"=ｲﾝｽﾄ", "\"V\":歌付", "\"T\"=歌詞のみ" };

        public static string[] IL = { "", "I", "L" };
        public static string[] ILVal = { "", "I:IMPORTED（海外音源使用）", "L:LOCAL（国内音源使用）" };

        public static string[] IVT = { "", "I", "V" };
        public static string[] IVTVal = { "", "I:曲のみ", "V:歌詞付" };

        public static string[] ContentType = { "", "Q" };
        public static string[] ContentTypeVal = { "", "Q" };

        public static string[] Medley = { "", "M" };
        public static string[] MedleyVal = { "", "M" };

        public static string[] OrgLyricTranslateType = { "", "1", "2", "3" };
        public static string[] OrgLyricTranslateTypeVal = { "", "1", "2", "3" };

        public static string[] Copyrignt = { "", "JASRAC", "JASRAC（歌詞付）", "E-LICENSE", "E-LICENSE（歌詞付）", "その他4%", "その他7.7%", "保留", "なし（発生しない）", "なし（消滅）", "なし（原盤印税に含む）", "その他(歌詞付)8.85%", "JRC", "なし（K-STREET）", "ds-copyright" };
        public static string[] CopyrigntVal = { "", "JASRAC", "JASRAC（歌詞付）", "e-license", "e-license（歌詞付）", "その他4%", "その他7.7%", "保留", "なし（発生しない）", "なし（消滅）", "なし（原盤印税に含む）", "その他(歌詞付)8.85%", "JRC", "なし（K-street）", "ds-copyright"};

        public static int LogActionSelectId = 1;
        public static int LogActionInsertId = 2;
        public static int LogActionUpdateId = 3;
        public static int LogActionDeleteId = 4;

        public static int LogOperationEnvironmentId = 1;//環境設定;                
        public static int LogOperationUserId = 2;//"担当者";                
        public static int LogOperationContractorId = 3;// "契約者";        
        public static int LogOperationArtistId = 4;//"アーティスト";             
        public static int LogOperationSongId = 5;//"楽曲";        
        public static int LogOperationPaymentId = 6;//"支払";                

        public static int LogOperationAlbumId = 7;//"アルバム";                
        public static int LogOperationGenreId = 8;//"ジャンル";                
        public static int LogOperationLabelId = 9;// "レーベル";        
        public static int LogOperationLyricId = 10;//"歌詞";             
        public static int LogOperationMusicStyleId = 11;//"楽曲スタイル";        
        public static int LogOperationSongMediaId = 12;//"歌";                
        public static int LogOperationSongSiteId = 13;//"曲サイト";

        public const int FileSizeUpdate = 1;//"ファイルサイズ更新"
        public const int SbLicencsKey = 2;//"SbﾗｲｾﾝｽｷｰDB入れ込み"
        public const int HaishinFlg = 3;//"更新（配信ﾌﾗｸﾞ）"
        public const int SbCreatorInf = 4;//"sb作者情報＆DRM作業情報"
        public const int OrgSongNameChange = 5;//"音源ファイル名変更"
        public const int MatsushitaChange = 6;//"松下変換用"
        public const int UtaCreate = 7;//"うたDB一括生成"
        public const int DocomoSpecial = 8;//"Docomoスペシャル"
        public const int Softbank = 9;//""
        public const int Toshiba = 10;//""
        public const int Matsushita = 10;//""
        public const int UtaRegister = 11;//""
        public const int AuUtaChange = 12;//""
        public const int ChangFlag = 13;//""
        // Binh add start
        public const int TrialListenAutoGen = 14;//""
        public const int UtaAutoGen = 15;//""
        // Binh add end
        public const int DocomoCareer = 0;//""
        public const int SoftbankCareer = 1;//""
        public const int AUCareer = 2;//""

        public static string[] OngenType = { "wav", "mp4", "3g2", "amc", "kmf", "t3g" };

        public static string[] ImportMstName = { "アーティスト", "アルバム", "ジャンル", "契約者", "レーベル", "スタイル" };
        public static string[] ImportMstDbRef = { "ArtistTemp", "AlbumTemp", "GenreTemp", "ContratorTemp", "LabelTemp", "MusicStyleTemp" };

        public static string[] ImportArtistHeader = { "ArtistId", "ｱｰﾃｨｽﾄ名", "ｱｰﾃｨｽﾄ名ﾖﾐ", "ｱｰﾃｨｽﾄ名ﾖﾐﾌﾙ", "ﾌﾟﾛﾌｨﾙ", "写真あり", "NdFlag", "専用Aサイト", "専用Bサイト", "AddId", "元のアーティスト" };
        public static string[] ImportArtistDbRef = { "ArtistId", "Name", "NameReading", "NameReadingFull", "Profile", "PhotoFlag", "NdFlag", "ASite", "BSite", "AddId", "ArtistNameO" };

        public static string[] ImportAlbumHeader = { "AlbumId", "ｱﾙﾊﾞﾑ名", "ｱﾙﾊﾞﾑ名ﾖﾐ", "ｱﾙﾊﾞﾑ名ﾖﾐﾌﾙ", "ｺﾒﾝﾄ", "CD品番", "JacketFlag", "PlFlag", "販売日" };
        public static string[] ImportAlbumDbRef = { "AlbumId", "text_label", "TitleReading", "TitleReadingFull", "Comment", "CdId", "JacketFlag", "PlFlag", "SaleDate" };

        public static string[] ImportGenreHeader = { "GenreId", "ｼﾞｬﾝﾙ名", "SoftBankGID" };
        public static string[] ImportGenreDbRef = { "GenreId", "Name", "SoftBankGID" };

        public static string[] ImportContractorHeader = { "KYID", "契約者名", "担当者", "郵便番号", "住所1", "住所2", "住所3", "ビル名", "電話番号", "振込先金融機関", "支店", "種別", "名義", "メモ", "配分方法", "配分率ﾌﾙ", "配分率うた", "配分率ビデオ", "updatemass", "口座番号", "ACID", "PWD", "契約開始日", "契約終了日", "支払いサイト", "締日パターン", "EMAIL_1", "EMAIL_2", "EMAIL_3", "繰越金額", "担当_1", "担当_2", "担当_3", "処理済", "前回締め日", "前回繰越金額", "個別報告日", "非表示", "個別報告" };
        public static string[] ImportContractorDbRef = { "ContractorId", "Name", "Manager", "PostNo", "Address1", "Address2", "Address3", "Building", "Telephone", "BankName", "BankBranchName", "BankType", "AccountName", "Note", "HbunMethod", "HbunRitsuFull", "uta_rate", "video_rate", "OpenDate", "AccountNo", "AcId", "Pwd", "StartDate", "EndDate", "PaySite", "PayPattern", "Email1", "Email2", "Email3", "Krkoshi", "Tantou1", "Tantou2", "Tantou3", "EndFlag", "LastPayDate", "LastKrkoshi", "ReportDate", "viewFlag", "SpecReport" };

        public static string[] ImportLabelHeader = { "LabelId", "ﾚｰﾍﾞﾙ名", "コメント" };
        public static string[] ImportLabelDbRef = { "LabelId", "Name", "Comment" };

        public static string[] ImportMusicStyleHeader = { "SID", "SID名" };
        public static string[] ImportMusicStyleDbRef = { "MusicStyleId", "Name" };

        public static string[] ArtistSameDataFieldChk = { "Name", "NameReadingFull" };
        public static string[] AlbumSameDataFieldChk = { "text_label", "TitleReadingFull", "CdId" };
        public static string[] GenreSameDataFieldChk = { "Name" };
        public static string[] ContractorSameDataFieldChk = { "Name", "Manager", "PostNo", "Address1", "Address2", "Address3", "Building", "Telephone", "BankName", "BankBranchName", "BankType", "AccountName", "Note", "HbunMethod", "HbunRitsuFull", "HbunRitsuUta", "OpenDate", "AccountNo", "AcId", "Pwd", "StartDate", "EndDate", "PaySite", "PayPattern", "Email1", "Email2", "Email3", "Krkoshi", "Tantou1", "Tantou2", "Tantou3", "EndFlag", "LastPayDate", "LastKrkoshi", "ReportDate", "SpecReport", "HbunRitsu", "uta_rate", "video_rate", "viewFlag" };
        public static string[] LabelSameDataFieldChk = { "Name" };
        public static string[] MusicStyleSameDataFieldChk = { "Name" };

        public static string[] ImportWaterIndexDataHeader = {"NAMTHANG","MACC","MACH","CSC","CSM"};
        public static string[] ImportWaterIndexDataDbRef = {   "YearMonth","TenementID","FlatID","OldIndex","NewIndex"};

        public static string[] ImportFlatDataHeader = { "MACC", "MACH", "TENCH", "CANHO", "DIENTHOAI", "DIENTICH", "SONGUOI", "GHICHU", "DINHMUCNUOC", "NGAYNHAN" };
        public static string[] ImportFlatDataDbRef = { "TenementID", "DisplayId", "Name", "Address", "Phone", "Area", "Persons", "Comment", "WaterFeeType", "ReceiveDate" };

        public static string[] ImportPrePaitdDataHeader = { "MACC"      , "MACH"  , "TIEN" , "LOAI", "NGAYNHAN"   , "NGUOINHAN", "NGUOIGUI", "GHICHU" , "NAMTHANG" };
        public static string[] ImportPrePaitdDataDbRef = {  "TenementID", "FlatID", "Money", "Type", "ReceiveDate", "Receiver" , "Form"    , "Comment", "YearMonth"};

        public static string[] ImportOtheFeeDataHeader = { "NAMTHANG"  , "MACC"     , "MACH"  , "TENLOAI", "SOLUONG" , "DONGIA", "GHICHU"};
        public static string[] ImportOtheFeeDataDbRef = {  "YearMonth" ,"TenementID", "FlatID", "Name"   , "mount"   , "Price", "Comment"};
        


        public static string[] SongMediaExt = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R" };
        public static string[] VideoMediaExt = { "V" };

        public static int UploadRecordNumber = 10000;
        public static int DownloadRecordNumber = 10000;

        public static string[] MosDate = { "新規", "テキスト", "コンテンツ", "削除" };
        public static string[] MosDateVal = { "1", "2", "3", "4" };


        public static string[] ImportRbtHeader = {   "WID","FID","text_label","TitleYomi","ArtistAID","GenreGID","GEID","Price","AlbumID","Album","LabeLID",
                                                    "Songwrite","Composer","CopyrightCODE","CMCompany","Time","DLConunt","PRText","Sabi1","Sabi2","Sabi3",
                                                    "Sabi1end","Sabi2end","Sabi3end","POINT1","POINT2","POINT3","Audition","PTNUM","SID","RID","Track_number",
                                                    "Flag","rank_t_week","rank_b_week","rank_t_month","rank_b_month","SPID","コンテンツ区分","コンテンツ枝番",
                                                    "メドレー区分","メドレー枝番","コレクトコード","ＪＡＳＲＡＣ作品コード","原題名","副題・邦題","作詞者名",
                                                    "補作詞・訳詞者名","作曲者名","編曲者名","アーティスト名","情報料（税抜）","IVT","原詞訳詞区分","IL区分",
                                                    "リクエスト回数1","リクエスト回数2","リクエスト回数3","New","Plus","GSN","Tryurl","Dlurl","Fineflg",
                                                    "FsizeDL","FsizeTRY","UPDATE","配信停止日","WPflg","RCflg","TitleYomiFull","TrackNo","OATID","CoverFlg","Kokoflg",
                                                    "ISRC番号","著作権管理団体","支払方法","税抜価格","契約者ID","契約者","著作権料契約者ID","楽曲使用料単価",
                                                    "著作権料単価","KDDI手数料単価","率","利益単価","IVT区分","PAID","推し曲","DCflg","SBflg","FsizeDC","FsizeSB",
                                                    "FsizeAU","MemberOnlyDC","NoTryalDC","TryalOnlyDC","MemberOnlySB","NoTryalSB","TryalOnlySB","MemberOnlyAU","NoTryalAU",
                                                    "TryalOnlyAU","memo","fLID","tLID","fCID","tCID"
                                            };
        public static string[] ImportRbtDbRef = {   "SongMediaId","SongId","text_label","TitleReading","ArtistId","GenreId","GEID","Price","AlbumId","Album","LabelId",
                                                    "Songwrite","Composer","CopyrightCODE","CMCompany","Time","DLConunt","PRText","Sabi1","Sabi2","Sabi3","Sabi1End",
                                                    "Sabi2End","Sabi3End","Point1","Point2","Point3","Audition","PTNUM","MusicStyleId","RID","TrackNumber","Flag",
                                                    "rank_t_week","rank_b_week","rank_t_month","rank_b_month","SPID","ContentType","ContentBranch","MedleyType",
                                                    "MedleyBranch","CollectCode","JasracWorksCode","OriginalTitle","SubTitle","SongWriter","SongTranslator",
                                                    "SongComposer","SongArranger","ArtistName","Fee","IVT","OriginalTranslationType","ImportType","Request1",
                                                    "Request2","Request3","ReserveFlag","Plus","GSN","TrialUrl","DownloadUrl","FineFlag","DownloadFileSize",
                                                    "TrialDownloadFileSize","HaishinDate","HaishinEndDate","WallPaperFlag","ArrivalRecommendFlag","TitleReadingFull",
                                                    "TrackCount","OriginalArtistId","CoverFlag","KoKoFlag","IsrcNo","CopyrightContractorId","PaymentType","PriceNoTax",
                                                    "ContractorId","Contractor","CopyrightContractId","BuyUnique","CopyrightFeeUnique","KDDICommissionUnique",
                                                    "Rate","ProfitUnique","IVTType","PAId","RecommendFlag","ImodeFlag","SBankFlag","ImodeFileSize","SBankFileSize",
                                                    "EzwebFileSize","ImodeMemberOnlyFlag","ImodeNoTrialFlag","ImodeTrialOnlyFlag","SBankMemberOnlyFlag","SBankNoTrialFlag",
                                                    "SBankTrialOnlyFlag","EzwebMemberOnlyFlag","EzwebNoTrialFlag","EzwebTrialOnlyFlag","Memo","FullLicenseId",
                                                    "TrialLicenseId","FullContentId","TrialContentId"
                                            };
        public static string FileSizePath = "FileSizePath";
        public static string SbLicencsePath = "SbLicencsePath";
        public static string DocomoSpecialPath = "DocomoSpecialPath";
        public static string SoftbankPath = "SoftbankPath";
        public static string ToshibaPath = "ToshibaPath";
        public static string MatsushitaWavPath = "MatsushitaWavPath";
        public static string MatsushitaJakPath = "MatsushitaJakPath";
        public static string MatsushitaWrdPath = "MatsushitaWrdPath";
        public static string UtaChangeInPath = "UtaChangeInPath";
        public static string UtaChangeOutPath = "UtaChangeOutPath";
        public static string SbVideoClipPath = "SbVideoClipPath";
        public static string DcVideoClipPath = "DcVideoClipPath";
        public static string MosDateVideoPath = "MosDateVideoPath";
        public static string UtaRigisterPath = "UtaRigisterPath";

        public static string FileSizeFPath = "FileSizeFPath";
        public static string FileSizeVPath = "FileSizeVPath";
        public static string SoftbankFPath = "SoftbankFPath";
        public static string SoftbankUPath = "SoftbankUPath";
        public static string MatsushitaWavFPath = "MatsushitaWavFPath";
        public static string MatsushitaJakFPath = "MatsushitaJakFPath";
        public static string MatsushitaWrdFPath = "MatsushitaWrdFPath";
        public static string MatsushitaWavVPath = "MatsushitaWavVPath";
        public static string MatsushitaJakVPath = "MatsushitaJakVPath";
        public static string MatsushitaWrdVPath = "MatsushitaWrdVPath";
        public static string OrgFilePath = "OrgFilePath";
        public static string AuWavPath = "AuWavPath";
        public static string AuOuputPath = "AuOuputPath";
        public static string UtaRigisterUPath = "UtaRigisterUPath";
        public static string UtaRigisterVPath = "UtaRigisterVPath";
        public static string MoveFilePath = "MoveFilePath";
        public static string RBT = "DcVideoClip";
        public static string RbtUploadPath = "RbtUploadPath";
        // Binh add start
        public static string TrialListenAutoGenInputPath = "TrialListenAutoGenInputPath";
        public static string TrialListenAutoGenOutputPath = "TrialListenAutoGenOutputPath";
        public static string UtaAutoGenInputPath = "UtaAutoGenInputPath";
        public static string UtaAutoGenOutputPath = "UtaAutoGenOutputPath";
        // Binh add end
        public static string[] ImportCommonFullHeader = {   "WID","text_label","ArtistAID","Artist名","AlbumID","Album名","Track_number","原詞訳詞区分",
                                                        "契約者ID","契約者名","切り出し表記1","cut開始1","cut終了1","切り出し表記2","cut開始2",
                                                        "cut終了2","切り出し表記3","cut開始3","cut終了3","Audition","IVT","UPDATE","更新" };

        public static string[] ImportCommonFullDbRef = {   "SongMediaId","text_label","ArtistId","ArtistName","AlbumId","Albumname","TrackNumber","OriginalTranslationType",
                                                        "ContractorId","ContractorName","Point1","Sabi1","Sabi1End","Point2","Sabi2","Sabi2End","Point3","Sabi3",
                                                        "Sabi3End","Audition","IVT","HaishinDate","[Update]"};

        public static string[] ImportCommonVideoHeader = {   "WID","FID","text_label","ArtistAID","Artist名","AlbumID","Album名","Track_number","原詞訳詞区分",
                                                        "契約者ID","契約者名","切り出し表記1","cut開始1","cut終了1","切り出し表記2","cut開始2",
                                                        "cut終了2","切り出し表記3","cut開始3","cut終了3","Audition","IVT","UPDATE","更新" };

        public static string[] ImportCommonVideoDbRef = {   "SongMediaId","SongId","text_label","ArtistId","ArtistName","AlbumId","Albumname","TrackNumber","OriginalTranslationType",
                                                        "ContractorId","ContractorName","Point1","Sabi1","Sabi1End","Point2","Sabi2","Sabi2End","Point3","Sabi3",
                                                        "Sabi3End","Audition","IVT","HaishinDate","[Update]"};


        public static string[] invalidChar = { "\\", "/", ":", "*", "?", "\"", "<", ">", "|", ";", ",", "." };



        public static string[] ImportFullDataHeader = { "WID", "曲名(半角)", "曲名ﾖﾐ(半角)", "曲名英表記", "解禁日（フル）", "配信停止日", "歌詞区分", "価格", "ISRC番号", "切り出し表記1", "cut開始1", "cut終了1", "切り出し表記2", "cut開始2", "cut終了2", "切り出し表記3", "cut開始3", "cut終了3", "fineflag", "フルファイル名" };

        public static string[] ImportFullDataDbRef = { "SongId", "SongTitle", "SongTitleYomFullChar", "AlphabetTitle", "RemoveDateFull", "HaishinEndDate", "IVT", "Price", "IsrcNo", "Point1", "Sabi1", "Sabi1End", "Point2", "Sabi2", "Sabi2End", "Point3", "Sabi3", "Sabi3End", "Flag", "FullFileName" };

        public static string[] ImportUtaDataHeader = { "WID","解禁日（うた）","配信停止日（うた）","価格(うた)",
                                                         "うたﾀｲﾄﾙ名A","うたﾀｲﾄﾙ名B","うたﾀｲﾄﾙ名C","うたﾀｲﾄﾙ名D","うたﾀｲﾄﾙ名E","うたﾀｲﾄﾙ名F","うたﾀｲﾄﾙ名G","うたﾀｲﾄﾙ名H","うたﾀｲﾄﾙ名I","うたﾀｲﾄﾙ名J","うたﾀｲﾄﾙ名K","うたﾀｲﾄﾙ名L","うたﾀｲﾄﾙ名M","うたﾀｲﾄﾙ名N","うたﾀｲﾄﾙ名O","うたﾀｲﾄﾙ名P","うたﾀｲﾄﾙ名Q","うたﾀｲﾄﾙ名R",
                                                         "うたISRCA","うたISRCB","うたISRCC","うたISRCD","うたISRCE","うたISRCF","うたISRCG","うたISRCH","うたISRCI","うたISRCJ","うたISRCK","うたISRCL","うたISRCM","うたISRCN","うたISRCO","うたISRCP","うたISRCQ","うたISRCR",
                                                         "うたファイル名A","うたファイル名B","うたファイル名C","うたファイル名D","うたファイル名E","うたファイル名F","うたファイル名G","うたファイル名H","うたファイル名I","うたファイル名J","うたファイル名K","うたファイル名L","うたファイル名M","うたファイル名N","うたファイル名O","うたファイル名P","うたファイル名Q","うたファイル名R"
                                                     };
        public static string[] ImportUtaDataDbRef = {   "SongId","RemoveDateUta","HaishinEndDateUta","PriceUta",
                                                        "UtaTitleA","UtaTitleB","UtaTitleC","UtaTitleD","UtaTitleE","UtaTitleF","UtaTitleG","UtaTitleH","UtaTitleI","UtaTitleJ","UtaTitleK","UtaTitleL","UtaTitleM","UtaTitleN","UtaTitleO","UtaTitleP","UtaTitleQ","UtaTitleR",
                                                        "UtaIsrcNoA","UtaIsrcNoB","UtaIsrcNoC","UtaIsrcNoD","UtaIsrcNoE","UtaIsrcNoF","UtaIsrcNoG","UtaIsrcNoH","UtaIsrcNoI","UtaIsrcNoJ","UtaIsrcNoK","UtaIsrcNoL","UtaIsrcNoM","UtaIsrcNoN","UtaIsrcNoO","UtaIsrcNoP","UtaIsrcNoQ","UtaIsrcNoR",
                                                        "UtaFileNameA","UtaFileNameB","UtaFileNameC","UtaFileNameD","UtaFileNameE","UtaFileNameF","UtaFileNameG","UtaFileNameH","UtaFileNameI","UtaFileNameJ","UtaFileNameK","UtaFileNameL","UtaFileNameM","UtaFileNameN","UtaFileNameO","UtaFileNameP","UtaFileNameQ","UtaFileNameR"
                                                    };
        public static string[] ImportNewRbtHeader = { "WID", "FID", "text_label", "Price", "UPDATE", "配信停止日", "ISRC番号" };
        public static string[] ImportNewRbtDbRef = { "SongMediaId", "SongId", "text_label", "Price", "HaishinDate", "HaishinEndDate", "IsrcNo" };

        public static string[] ImportUpdateSongPRTextHeader = { "SongMediaId", "text_label", "AID", "ArtistName", "AlbumID", "Album", "契約者ID", "契約者名", "PRText" };
        public static string[] ImportUpdateSongPRTextDbRef = { "Id", "text_label", "ArtistId", "ArtistName", "AlbumId", "AlbumName", "ContractorId", "ContractorName", "PRText" };

        public static string[] ImportUpdateAlbumCommentHeader = { "AlbumID", "Album", "CDID", "AID", "ArtistName", "契約者名", "発売日", "Comment", "写FL" };
        public static string[] ImportUpdateAlbumCommentDbRef = { "Id", "AlbumName", "CDID", "ArtistId", "ArtistName", "ContractorName", "SaleDate", "Comment", "JacketFlag" };

        public static string[] ImportUpdateArtistProfileHeader = { "ArtistId", "ArtistName", "契約者名", "Profile" };
        public static string[] ImportUpdateArtistProfileDbRef = { "Id", "ArtistName", "ContractorName", "Profile" };

        // Binh add start
        public static string[] ImportUpdateJasracHeader = { "インターフェイスキーコード","コンテンツ区分","コンテンツ枝番","メドレー区分","メドレー枝番","コレクトコード","JASRAC作品コード","JASRAC作品名","副題・邦題","作詞者名","補作詞・訳詞者名","作曲者名","編曲者名","アーティスト名","情報料（税抜）","IVT区分","原詞訳詞区分","IL区分","リクエスト回数","作品内外区分","コンテンツ単位使用料（税抜き）","適用レート","徴収率","削除追加区分","請求計算結果コード" };
        public static string[] ImportUpdateJasracDbRef = { "InterfaceKeyCode_NotifyNumber", "ContentType", "ContentBranch_JRCUserCode", "MedleyType", "MedleyBranch", "CollectCode", "WorksCode", "WorksName", "SubTitle_OriginalTitle", "SongWriter_Copyrighter", "SongTranslator", "SongComposer_UseClassification", "SongArranger_TracingBack", "ArtistName", "InfoFee_TaxIncludePrice", "IVTType", "OriginalTranslationType", "ImportType", "RequestCount_UseCount", "WorksOutsideType", "ContentUnitUseFee", "ApplyRate", "CollectionRatio", "DeleteAddType", "RequestCalculateResultCode", "ConsentNumber", "ActualResultYearMonth" };

        public static string[] ImportUpdateeLicenseHeader = { "許諾番号", "実績期間", "遡及", "インターフェイスキーコード", "コンテンツ区分", "コンテンツ枝番", "メドレー区分", "メドレー枝番", "e-License 作品番号", "原題名 (曲名)", "アーティスト名", "情報料 (税抜)", "IVT区分", "リクエスト回数", "適用レート", "徴収率", "コンテンツ単位使用料（税抜き）" };
        public static string[] ImportUpdateeLicenseDbRef = { "ConsentNumber", "ActualResultYearMonth", "SongArranger_TracingBack", "InterfaceKeyCode_NotifyNumber", "ContentType", "ContentBranch_JRCUserCode", "MedleyType", "MedleyBranch", "WorksCode", "SubTitle_OriginalTitle", "ArtistName", "InfoFee_TaxIncludePrice", "IVTType", "RequestCount_UseCount", "ApplyRate", "CollectionRatio", "ContentUnitUseFee" };

        public static string[] ImportUpdateJRCHeader = { "許諾番号", "報告番号", "利用月", "JRC利用者コード", "利用種別", "JRC作品コード", "IVT区分", "作品名", "アーティスト", "権利者", "徴収率", "使用数", "使用料率", "使用率", "単価控除率", "計算対象数", "使用料単価", "使用料", "備考" };
        public static string[] ImportUpdateJRCDbRef = { "ConsentNumber", "InterfaceKeyCode_NotifyNumber", "ActualResultYearMonth", "ContentBranch_JRCUserCode", "SongComposer_UseClassification", "WorksCode", "IVTType", "WorksName", "ArtistName", "SongWriter_Copyrighter", "CollectionRatio", "RequestCount_UseCount", "UseFeeRate", "UseRate", "PriceDeductionRate", "CalculationTargerCount", "UseFeePrice", "ContentUnitUseFee", "Comment" };
        // Binh add end

        public static string[] ImportRbtDownloadHeader = { "コンテンツID", "CP-ID", "サイトID", "コンテンツ名", "アーティスト名", "有料フラグ", "課金額", "月初設定", "1日", "2日", "3日", "4日", "5日", "6日", "7日", "8日", "9日", "10日", "11日", "12日", "13日", "14日", "15日", "16日", "17日", "18日", "19日", "20日", "21日", "22日", "23日", "24日", "25日", "26日", "27日", "28日", "29日", "30日", "31日" };
        public static string[] ImportRbtDownloadDbRef = { "ContentId", "CpId", "SiteId", "ContentName", "ArtistName", "FeeFlag", "Charge", "BeginMonth", "Day01", "Day02", "Day03", "Day04", "Day05", "Day06", "Day07", "Day08", "Day09", "Day10", "Day11", "Day12", "Day13", "Day14", "Day15", "Day16", "Day17", "Day18", "Day19", "Day20", "Day21", "Day22", "Day23", "Day24", "Day25", "Day26", "Day27", "Day28", "Day29", "Day30", "Day31" };

        public static string[] ImportRbtDownloadAuHeader = { "Myリスト登録日時", "サービス提供者コード", "サービス提供者名", "サービスコード", "サービス名", "課金種別", "金額", "商品コード", "商品名", "サブスクライバID", "コンテンツコード", "無償端末有無", "同一月再購入有無" };
        public static string[] ImportRbtDownloadAuDbRef = { "DownloadDate", "ServiceSupportCode", "ServiceSupportName", "ServiceCode", "ServiceName", "ChargeType", "Price", "SiteCode", "SiteName", "UserId", "ContentCode", "TerminalFlag", "BeginMonth" };

        public static string[] ImportRbtDownloadSbHeader = { "登録（購入）・解約日時", "PID", "プロバイダ名", "SID", "サイト名", "課金・解除種別", "金額", "コンテンツ名", "UID", "CID" };
        public static string[] ImportRbtDownloadSbDbRef = { "DownloadDate", "ServiceSupportCode", "ServiceSupportName", "ServiceCode", "SiteName", "ChargeType", "Price", "ContentName", "UserId", "ContentCode" };

        public static string[] ImportScheduleHeader = { "共通", "フルのみ", "うたのみ", "ビデオクリップ", "待ちうた", "解禁日", "配信日", "権利者", "アーティスト名", "曲数（共通、フルのみ、うたのみ）", "曲数（ビデオクリップ）", "曲数（待ちうた）", "歌詞", "注意1（共通、フルのみ、うたのみ）", "注意2（ビデオクリップ）", "注意3（待ちうた）", "備考（共通、フルのみ、うたのみ）", "備考（ビデオクリップ）", "備考（待ちうた）", "展開条件" };
        public static string[] ImportScheduleDbRef = { "CommonFlag", "FullOnlyFlag", "UtaOnlyFlag", "VideoClipFlag", "MachiUtaFlag", "HaishinStartDate", "HaishinDate", "Contractor", "ArtistName", "SongNumsCommon", "SongNumsVideoClip", "SongNumsMachiUta", "LyricsFlag", "AttentCommon", "AttentVideoClip", "AttentMachiUta", "CommentCommon", "CommentVideoClip", "CommentMachiUta", "ExpandCondition" };

        public static string[] ImportNewKaraokeHeader = { "WID", "FID", "text_label", "Price", "UPDATE", "配信停止日", "ISRC番号", "紐付けWID" };
        public static string[] ImportNewKaraokeDbRef = { "SongMediaId", "SongId", "text_label", "Price", "HaishinDate", "HaishinEndDate", "IsrcNo", "LinkSongId" };

        public static string[] ImportNewMeloHeader = { "WID", "FID", "text_label", "Price", "UPDATE", "配信停止日", "ISRC番号" };
        public static string[] ImportNewMeloDbRef = { "SongMediaId", "SongId", "text_label", "Price", "HaishinDate", "HaishinEndDate", "IsrcNo" };

    }
}
