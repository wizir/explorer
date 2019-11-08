import * as React from 'react';
import * as ReactDOM from 'react-dom';

type PropType = {
    pages: string[]
}
const Diary = (props) => {
    const pages = props.params;
    console.log(pages);
     return (
         <div>
             {/*{pages.map(page =>*/}
             {/*    (*/}
             {/*        <div>*/}
             {/*            <a>{page.title}</a>*/}
             {/*        </div>*/}
             {/*    ))}*/}
            this is component
         </div>
     )   
};

const node = document.getElementById('diaryRoot');
const params = node.getAttribute('params');
ReactDOM.render(<Diary params={params}/>, node);