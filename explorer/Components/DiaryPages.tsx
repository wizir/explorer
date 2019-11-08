import * as React from "react";
import {Page} from "./Model/Page";


const DiaryPages = (props : {params: Page[] }) => {
    
    const pages = props.params;
    console.log(pages);
    console.log('pages');
    return(
        <div>
        {pages.map(page =>
            (
             <a key={page.id}>
                 <h2>{page.title}</h2>
             </a>   
            )
            
        )}  
        </div>      
    )
};
    

export default DiaryPages;