var windowName;

function PopUp(url, width, height)
{
	//Fixed IE Bug
	//See http://support.microsoft.com/kb/269658/en-us
	if (typeof windowName == "object" && windowName.closed == false && windowName.name == name) {
		   windowName.location.replace(url);
		   windowName.focus();
	}
	else
	{
	    windowName =window.open(url,'win',
	    "height=" + height+  " ,width=" + width + " ,status=no,toolbar=no,scrollbars=no,resizable=no,menubar=no,location=no");
	    windowName.focus();
	}
}

function PopUp(url, width, height, name)
{
    if (typeof windowName == "object" && windowName.closed == false && windowName.name == name) {
		   windowName.location.replace(url);
		   windowName.focus();
	}
	else{
	    windowName =window.open(url,name,
	    "height=" + height+  " ,width=" + width + " ,status=no,toolbar=no,scrollbars=no,resizable=no,menubar=no,location=no");
	    windowName.focus();
	}
}


function PopUp(url, width, height, name, isScroll)
{
	if (typeof windowName == "object" && windowName.closed == false && windowName.name == name) {
		    windowName.location.replace(url);
		    windowName.focus();
	}
	else
	{
	    
	    windowName =window.open(url,name,
	    "height=" + height+  " ,width=" + width + " ,status=no,toolbar=no,scrollbars="  + (isScroll? "yes" : "no") + ",resizable=no,menubar=no,location=no", true);
	    windowName.location.replace(url);
	     windowName.focus();
	}
}

function OpenMedia(baitaiId)
{
    PopUp("/Media/EditMediaInfo.aspx?act=update&mediaId=" + baitaiId,800,730,"OpenBaitaiDetail",true);
}

function OpenMedia(baitaiId, isGraph)
{
    PopUp("/Media/EditMediaInfo.aspx?act=update&mediaId=" + baitaiId + "&meminfo=" + isGraph ,800,730,"OpenBaitaiDetail",true);
}

function OpenClickResult(ankenDetailId)
{
    PopUp("/Anken/ViewClickResult.aspx?ankenDetailId=" + ankenDetailId,600,600,"OpenViewClickResult",true);
}

function PopUp(url, width, height, name, isScroll, isRefresh)
{
	if (typeof windowName == "object" && windowName.closed == false && windowName.name == name) {
		    windowName.location.replace(url);
		    windowName.focus();
	}
	else
	{
	    windowName =window.open(url,name,
	    "height=" + height+  " ,width=" + width + " ,status=no,toolbar=no,scrollbars="  + (isScroll? "yes" : "no") + ",resizable=no,menubar=no,location=no", true);
	    if(isRefresh)
	    {
	        windowName.location.replace(url);
	        windowName.focus();
	    }
	}
}

function PopUp2(url, width, height, name)
{
	if (typeof windowName == "object" && windowName.closed == false && windowName.name == name) {
		    windowName.location.replace(url);
	}
	else {
	windowName =window.open(url,name,
	"height=" + height+  " ,width=" + width + " ,status=no,toolbar=no,scrollbars=yes,resizable=no,menubar=no,location=no");
	windowName.focus();
	}
}

function PopUpSmall(url, width, height, name)
{
	if (typeof windowName == "object" && windowName.closed == false && windowName.name == name) {
		   windowName.location.replace(url);
	}
	else {
	windowName =window.open(url,name,
	"height=" + height+  " ,width=" + width + " ,status=no,toolbar=no,scrollbars=no,resizable=no,menubar=no,location=no");
	windowName.focus();
	}
}

function OpenSameWindow(url, width, height, isScroll)
{
	if (typeof windowName == "object") {
		   windowName.location.replace(url);
	}
	else {
	windowName =window.open(url,window.name,
	"height=" + height+  " ,width=" + width + " ,status=no,toolbar=no,scrollbars="  + (isScroll? "yes" : "no") + ",resizable=no,menubar=no,location=no");
	windowName.focus();
	}
}


function DateAdd(timeU,byMany,dateObj) {
	var millisecond=1;
	var second=millisecond*1000;
	var minute=second*60;
	var hour=minute*60;
	var day=hour*24;
	var year=day*365;

	var newDate;
	var dVal=dateObj.valueOf();
	//dVal = dValreplace("/","")
	switch(timeU) {
		case "ms": newDate=new Date(dVal+millisecond*byMany); break;
		case "s": newDate=new Date(dVal+second*byMany); break;
		case "mi": newDate=new Date(dVal+minute*byMany); break;
		case "h": newDate=new Date(dVal+hour*byMany); break;
		case "d": newDate=new Date(dVal+day*byMany); break;
		case "y": newDate=new Date(dVal+year*byMany); break;
	}
	return formatDate(newDate, "yyyy/MM/dd"); 
}


function disableParentObj(obj, toObj)
{
	if(obj.value != "-1")
	{
		toObj.value = "";
		toObj.style.backgroundColor  = "#DEDEDE";
		toObj.disabled = true;
		opener.document.getElementById("div_" + toObj.name  ).style.visibility='hidden';
	}
	else
	{
		toObj.disabled = false;
		toObj.style.backgroundColor  = "#FFFFFF";		
		opener.document.getElementById("div_" + toObj.name  ).style.visibility='visible';
	}
}	

function confirmSubmit( text)
{
	if(!confirm(text))
	{
		return false;
	}
	return true;
}

//object id of region checkbox
//checkboxName checkbox name
function CheckBoxCheck( object, checkboxName){
				
	var state = false;
				
	for( i=0;i< object.all.length;i++ ){    
		if((object.all[i].type == 'checkbox')&&(object.all[i].name.indexOf(checkboxName)>=0)&&(!object.all[i].checked)&&(!object.all[i].disabled)) {
			state = true
			break;
		}
	}			
	for( i=0;i< object.all.length;i++ ){    
		if((object.all[i].type == 'checkbox')&&(object.all[i].name.indexOf(checkboxName)>=0)) {
			if(!object.all[i].disabled){
				object.all[i].checked = state;					
			}
			else{
				object.all[i].checked = false;										
			}
		}
	}				
}

//object id of region checkbox
//checkboxName checkbox name
//chkval value to set
function CheckBoxCheckByValue(object, checkboxName, chkval){

	var state = chkval;
	
	for( i=0;i< object.all.length;i++ ){    
		if((object.all[i].type == 'checkbox')&&(object.all[i].name.indexOf(checkboxName)>=0)) {
			if(!object.all[i].disabled){
				object.all[i].checked = state;					
			}
			else{
				object.all[i].checked = false;										
			}
		}
	}				
}

function IsCheckBoxCheck( frm, checkboxName){
				
	var state = false;
				
	for( i=0;i< frm.elements.length;i++ ){    
		if((frm.elements[i].type == 'checkbox')&&(frm.elements[i].name.indexOf(checkboxName)>=0)&&(frm.elements[i].checked)&&(!frm.elements[i].disabled)) {
			state = true
			break;
		}
	}		
				
	return state;
}
 function CheckAllRepeater(aspCheckBoxID, checkVal) {
	var frm = document.forms[0];
    re = new RegExp(aspCheckBoxID + '$')  
    for(i = 0,m=frm.elements.length; i < m; i++) {
        elm = frm.elements[i]
        if (elm.type == 'checkbox' && re.test(elm.name) ) {
            elm.checked = checkVal
        }
    }
}

function CheckAllRepeaterSpecial(aspCheckBoxID, checkVal, prefix ) {
	var frm = document.forms[0];
    re = new RegExp(aspCheckBoxID + '$')  
    for(i = 0,m=frm.elements.length; i < m; i++) {
        elm = frm.elements[i]
        if (elm.type == 'checkbox' && re.test(elm.name) && elm.name.indexOf(prefix) != -1 ) {
            elm.checked = checkVal
        }
    }
}


//Format number as Integer
function FormatInt(num) { // 
if(num == undefined || num == null || num=="0") return 0 ;
if(num == "")
    return "";
if (CheckNumber(num) == 0) {
//alert("This does not appear to be a valid number.  Please try again.");
}
else { 
	num = num.toString().replace(/\$|\,/g,'');
	if(num.lastIndexOf('.') > 0 ) {
		num = num.substr(0, num.lastIndexOf('.'));
	}
	if(isNaN(num))
	{
		num = "";
		return;
	}
	sign = (num == (num = Math.abs(num)));
	cents = num%1000;
	num = Math.round(num).toString();
	if(cents<100)
		cents = "0" + cents;
	for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
	num = num.substring(0,num.length-(4*i+3))+','+
	num.substring(num.length-(4*i+3));
	//field.value = (((sign)?'':'-') + num + '.' + cents);
	num = (((sign)?'':'-') + num);
}
return num;
}

function FormatObjectInt(field)
{
    field.value = FormatInt(field.value);
}

function GetNumber(value)
{
	if(value == "")
	{
		return "0";
	}
	return value.toString().replace(/\$|\,/g,'');
}

//Format with decimal for net/gross
function FormatDecimal(num) { 
if(num == undefined || num == null || num=="0") return 0 ;
if(num == "")
    return "";
if (CheckNumber(num) == 0) {
//alert("This does not appear to be a valid number.  Please try again.");
}
else { 
	num = num.toString().replace(/\$|\,/g,'');
	if(isNaN(num))
	{
		num = "";
		return;
	}
	divider = 1000;
	len = 3;
	sign = (num == (num = Math.abs(num)));
	/*
	num = Math.floor(num*1000+0.50000000001);
	cents = num%1000;
	num = Math.floor(num/1000).toString();
	if(cents<10)
		cents = "00" + cents;
	if(cents<100)
		cents = "0" + cents;
	for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
	num = num.substring(0,num.length-(4*i+3))+','+
	num.substring(num.length-(4*i+3));
	num = (((sign)?'':'-') + num + '.' + cents);
	num = num.replace(".000","");
	*/
	workNum=Math.abs((Math.round(num*divider)/divider));
   workStr=""+workNum

   if (workStr.indexOf(".")==-1){workStr+="."}

   dStr=workStr.substr(0,workStr.indexOf("."));dNum=dStr-0
   pStr=workStr.substr(workStr.indexOf("."))

   while (pStr.length-1< len){pStr+="0"}

   
   while(pStr.charAt(pStr.length-1) == "0")
   {
        pStr = pStr.substr(0, pStr.length-1);
   }
   if(pStr =='.') pStr ='';
  

   //--- Adds a comma in the thousands place.    
   if (dNum>=1000) {
	  dLen=dStr.length
	  dStr=parseInt(""+(dNum/1000))+","+dStr.substring(dLen-3,dLen)
   }

   //-- Adds a comma in the millions place.
   if (dNum>=1000000) {
	  dLen=dStr.length
	  dStr=parseInt(""+(dNum/1000000))+","+dStr.substring(dLen-7,dLen)
   }
   retval = dStr + pStr
   //-- Put numbers in parentheses if negative.
   //if (anynum<0) {retval="("+retval+")";}
   retval = (((sign)?'':'-') + retval);
   
   return retval;
   }
   return num;
}

//function FormatObjectRoundDecimal(field)
//{
//    field.value = FormatRoundDecimal(field.value);
//}


////Format with decimal 
//function FormatUnRoundDecimal(num) { 
//if(num == undefined || num == null || num=="0") return 0 ;
//if(num == "")
//    return "";
//if (CheckNumber(num) == 0) {
////alert("This does not appear to be a valid number.  Please try again.");
//}
//else { 
//	num = num.toString().replace(/\$|\,/g,'');
//	if(isNaN(num))
//	{
//		num = "";
//		return;
//	}
//	left = "";
//	if(num.lastIndexOf('.') > 0 ) {
//		left = num.substr(num.lastIndexOf('.'), num.length);
//	}
//	sign = (num == (num = Math.abs(num)));
//	num = Math.floor(num*1000+0.50000000001);
//	cents = num%1000;
//	num = Math.floor(num/1000).toString();
//	if(cents<100)
//		cents = "0" + cents;
//	for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
//	num = num.substring(0,num.length-(4*i+3))+','+
//	num.substring(num.length-(4*i+3));
//	num = (((sign)?'':'-') + num +  left);
//	num = num.replace(".000","");
//}
//return num;
//}

function FormatObjectDecimal(field)
{
    field.value = FormatDecimal(field.value);
}


function CheckAllDataGridCheckBoxes(aspCheckBoxID, checkVal) {
    var len = document.getElementsByTagName("input").length;
    for (i = 0; i < len; i++) {
        
        if (document.getElementsByTagName("input")[i].type == 'checkbox' &&
            document.getElementsByTagName("input")[i].name.indexOf(aspCheckBoxID) != -1) {
            document.getElementsByTagName("input")[i].checked = checkVal.checked;
        }
    }
}

function SetValToTextBox(id01, selectedVal01, id02, selectedVal02) {
    window.opener.document.getElementById(id01).value = selectedVal01;
    window.opener.document.getElementById(id02).innerHTML = selectedVal02;   
    window.close();
}

function SetValToTextBoxOnly(id01, selectedVal01, id02, selectedVal02) {
    window.opener.document.getElementById(id01).value = selectedVal01;
    window.opener.document.getElementById(id02).value = selectedVal02;
    window.close();
}

function CheckBoxeSelected(aspCheckBoxID) {
    var syncFlg = false;
    var len = document.getElementsByTagName("input").length;
    for (i = 0; i < len; i++) {
        if (document.getElementsByTagName("input")[i].type == 'checkbox' &&
            document.getElementsByTagName("input")[i].name.indexOf(aspCheckBoxID) != -1 &&
            document.getElementsByTagName("input")[i].checked
            ) {
            syncFlg = true;
            break;
            //return true;
        }
    }

    if (!syncFlg) {
        alert("レコーダを選択してください。");
        return false;
    }
    len = document.getElementsByTagName("select").length;
    for (i = 0; i < len; i++) {
        if (document.getElementsByTagName("select")[i].name.indexOf("lstSiteSend") != -1 &&
            document.getElementsByTagName("select")[i].selectedIndex != -1) {
            return true;
        }
    }
    alert("サイトを選択してください。");
    return false;
}


function CheckNumber(data) {      // checks if all characters 
if(data == undefined || data == null || data=="0") return 0 ;

var valid = "0123456789.,";     // are valid numbers or a "."
var ok = 1; var checktemp;
for (var i=0; i<data.length; i++) {
checktemp = "" + data.substring(i, i+1);
if (valid.indexOf(checktemp) == "-1") return 0; }
return 1;
}

function UpdateChkAll(chkboxid, chkAllId) {
    var box = document.getElementById(chkboxid);
    var chkAllbox = document.getElementById(chkAllId);
    var chkFlag = 1; //make the default is true
    state = box.checked;
    elem = box.form.elements;
    if (state != 1)  // if that checkbox is unchecked, the chkAll box is unchecked, done, out of the function.
        chkAllbox.checked = state;
    else //ok, this box is checked, see if rest of the boxes are all checked, if all checked, the chkAll box is checked.
    {
        for (i = 0; i < elem.length; i++)
            if (elem[i].type == "checkbox" && elem[i].id != chkAllbox.id)
            if (elem[i].checked == 0) // one of them not checked
        {
            chkFlag = 0;
            chkAllbox.checked = 0; // still keep unchecked
        }

        if (chkFlag == 1) //that tells all other check boxes are checked after the for loop.
            chkAllbox.checked = 1;
    }
}

function SelectAll(chkboxid) //pass the top checkbox (select all check box)
{
    var box = document.getElementById(chkboxid);
    state = box.checked; //1 or 0
    elem = box.form.elements;

    for (i = 0; i < elem.length; i++) {

        if (elem[i].type == "checkbox" && elem[i].id != box.id && elem[i].name.indexOf("chkItem") != -1) {
            elem[i].checked = state;
        }
    }
}