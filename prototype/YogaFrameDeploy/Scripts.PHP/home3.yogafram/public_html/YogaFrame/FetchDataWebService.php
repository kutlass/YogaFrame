<?php

switch($method)
{ 
    case "getUserData":        
        /* grab the posts from the db */
        $query = "SELECT id,username,email FROM users WHERE status = '1' ORDER BY ID DESC LIMIT 1";
        $result = mysql_query($query,$link) or die('Errant query:  '.$query);
        
        /* create one master array of the records */
        $data = array();
        if( mysql_num_rows($result) )
        {
            while($row = mysql_fetch_assoc($result))
            {
                $data[] = $row;
            }
        }
        echo formatData($data,$format);
        break;
    default:
        $params = array("status":0,"msg":"Invalid Method Call");
        echo json_encode($params);
        exit;
    break;
}

function formatData($data,$format='json')
{
    /* output in necessary format */
    if($format == 'json')
    {
        header('Content-type: application/json'); 
        return json_encode(array('data'=>$data));
    }
    else
    {
        $response = '';
        header('Content-type: text/xml');
        $response .=  '<user>';
        foreach($data as $index => $data)
        {
            if( is_array($data) )
            {
                foreach($data as $key => $value)
                {
                    $response .=  '<',$key,'>';
                    if(is_array($value))
                    {
                        foreach($value as $tag => $val)
                        {
                            $response .=  '<',$tag,'>',htmlentities($val),'</',$tag,'>';
                        }
                    }
                    $response .= '</',$key,'>';
                }
            }
        }
        $response .= '</user>';
    }
    
    return $response;
}

?>
