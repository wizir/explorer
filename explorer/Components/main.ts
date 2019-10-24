
let number = 0;

export const counter = (nodeId: string) =>{
    setInterval(()=> {
        document.getElementById(nodeId).innerText = `${number++}`
    }, 1000);
};