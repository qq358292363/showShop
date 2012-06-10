/*
    Name:数据验证
    Author:sunqinqiu
    Time:2009-7-29
*/
String.prototype.trim=function()
{   
   return this.replace(/(^\s*)|(\s*$)/g, "");    
}
//验证是否为空
function IsNull(control,min,max){
    var str = control.value.trim();    
    if(str.length<min || str.length>max)
    {
        return false;
    }
    else
    {
        return true;
    }
}

//验证是不是网址
function IsHttpUrl(control)     
{     
    var str = control.value.trim();
    if(str.length!=0)
    {   
    
        var reg=/(http[s]?|ftp):\/\/[^\/\.]+?\..+\w$/i;
        
        if(!reg.test(str))
        {    
            return false;
        }
        else
        {
            return true;
        }
    }
    else
    {
        return false;
    }
}

//验证是不是邮箱
function IsEmail(control)     
{     
    var str = control.value.trim(); 
    if(str.length!=0)
    {    
        reg=/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;    
        if(!reg.test(str))
        {    
            return false;
        }
        else
        {
            return true;
        }
    }
    else
    {
        return false;
    }
}

//验证长度
function CheckLength(control,len)
{
    var str = control.value.trim(); 
    if(str.length<len)
    {
        return false;
    }
    else
    {
        return true;
    }
}
//验证长度等于多少
function CheckEqualsLeng(control,len)
{
    var str = control.value.trim(); 
    if(str.length!=len)
    {
        return false;
    }
    else
    {
        return true;
    }
}
//验证Int
function IsInt(control,min,max)     
{       
    var str = control.value.trim();

    if(str.length!=0)
    {
        reg=/^\d*$/;     
        if(reg.test(str))
        {    
            var strvalue=str.length;
            if(strvalue>=min && strvalue<=max)
            {
                return true;
            }
            return false;  
        }
        return false;
    }
    return false;
}  
//验证float
function IsFloat(control)     
{       
    var str = control.value.trim();
    if(str.length!=0)
    {
        reg=/^\d+(\.\d+)?$/;     
        if(!reg.test(str))
        {    
            return false;  
        }
        else
        {
            return true;
        }
    }
    else
    {
        return false;
    }
} 

function GetClass(result)
{
    if(result)
    {
        return "msgOK";
    }
    else
    {
        return "msgError";
    }
}
//比较字符串
function Compare(control)
{
    var str = control.value.trim();
    var str2=$(control.id+"Re").value.trim();
    if(str==str2)
    {
        return true;
    }else
    {
        return false;
    }
}

//
function CheckValue(control)
{
    var result=false;
    var controlId=control.id;
    var controlTip=control.tip;
    var validatetype=control.validatetype;
    var controlValue=control.value;
    var checkresult=false;
    if(validatetype=="no")
    {
        ChangeMessageClass(control,"msgOK")
        return true;
    }
    
    
    //进行分解
    var validate=validatetype;
    var min=1;
    var max=10000;
    var para;
    if(validatetype.indexOf("if")>-1)
    {
       if(controlValue=="")
       {
           validate=validatetype.replace("if","");
           return true;
       }
       else
       {
           validate=validatetype.replace("if","");
       }
    }
    else
    {
    
    }
    if(validatetype.indexOf("_")>-1)
    {
         para=validatetype.split("_");
         validate=para[0];
         if(para.length==2)
         {
            min=para[1];
         }
         if(para.length==3)
         {
            min=para[1];
            max=para[2];
         }
     }
     
    //比较两个字符串
    if(validate=="compare")
    {
        result=Compare(control);
        ChangeMessageClass(control,GetClass(result))
        return result;
    }
    //isnull
    if(validate.indexOf("isnull")>=0)
    {
        result=IsNull(control,min,max);
        ChangeMessageClass(control,GetClass(result))
        return result;
    }
    //isemail
    if(validate=="isemail")
    {
        result=IsEmail(control);
        ChangeMessageClass(control,GetClass(result))
        return result;
    }
    if(validate=="isint")
    {
        result=IsInt(control,min,max);
        ChangeMessageClass(control,GetClass(result))
        return result;
    }
    if(validate=="isfloat")
    {
        result=IsFloat(control);
        ChangeMessageClass(control,GetClass(result))
        return result;
    }
    if(validate=="ishttpurl")
    {
        result=IsHttpUrl(control);
        ChangeMessageClass(control,GetClass(result))
        return result;  
    }
     
}
function CheckForm()
{
    var result=true;
    var controls=document.forms[0].elements;
    for(i=0;i<controls.length;i++)
    {
       
       var control=controls[i];
       var controlTip=control.tip;
       if(controlTip!=null)
       {
           if(!CheckValue(control))
           {
                result= false;
           }
       }
    }
    return result;
}

//
function ChangeMessageClass(control,className)
{
    var messageTip=$(control.id+'Tip');
    messageTip.className =className;
    
    if((className=='msgNormal' || className=='msgOnFocus')&&control.warning!="")
    {
        messageTip.innerHTML=control.warning+"<br/>"+control.tip;
    }
    else if(className=='msgError'&&control.error!="")
    {
        messageTip.innerHTML=control.error+"<br/>"+control.tip;
    }
    else
    {
        messageTip.innerHTML=control.tip;
    }
}

function InitForm()
{
    
    var controls=document.forms[0].elements;
    for(i=0;i<controls.length;i++)
    {
       var control=controls[i];
       var controlTip=control.tip;
       if(controlTip!=null)
       {
          
           ChangeMessageClass(control,"msgNormal");
           //给控件注册事件
           control.onblur=function(){
                                        CheckValue(this);
                                    };
           control.onfocus=function(){
                                        ChangeMessageClass(this,"msgOnFocus");
                                     };
       }
    }

}

