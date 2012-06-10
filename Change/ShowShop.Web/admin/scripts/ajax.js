function GetStringInfo(url,controlid)
{
    new Ajax.Request(
                url,
                {
                    method: 'get',
                    encoding: 'GBK',
                    onSuccess: function(transport) 
                    {
                    var lblCheckInfo = $(controlid);
                    lblCheckInfo.update(transport.responseText);
                    }
                }
            ); 
}