import * as React from 'react';
import * as ReactDOM from 'react-dom';
import DiaryPages from '../../Components/DiaryPages';
import {Page} from "../../Components/Model/Page";


const node = document.getElementById('diaryRoot');

const attributeValue = node.getAttribute('params');
const pages = JSON.parse(attributeValue) as Page[];

ReactDOM.render(<DiaryPages params={pages}/>, node);