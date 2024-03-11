
addEventListener('DOMContentLoaded', async ()=>
{
    let form = document.querySelector('.FormApp');
    let input = document.querySelector('.InputInfo');
    let tbody = document.createElement("tbody");
    let table = document.querySelector('table');
    console.log(form)

    form.addEventListener('submit', (e)=>
    {
        e.preventDefault();
    });

    let Timer = setTimeout(()=>{},0);
    input.addEventListener('input', (e)=>
    {
        clearTimeout(Timer);
        let target = e.target;
        Timer = setTimeout(()=>{
            UpdateTable(e.target.value);
        },500);

        //let result = null;
        //UpdateTable(e.target.value)
    })
    

    async function UpdateTable(value)
    {
        if (value.length > 0)
        {
            await Server(value).then(data => 
                {
                    let result = null;
                    result = JSON.parse(data)
                    result.forEach(async (element) =>{
    
                        await UpdateInfo();
                        
                        let tr = document.createElement('tr');
                        tr.className = "TrInfo";
                        tr.innerHTML += `<td>${element.fileName}`;
                        let text = element.fileText.slice(0,20)+ "...";
                        tr.innerHTML +=  `<td>${text}`;
                        tr.innerHTML +=  `<td>${element.filePath}`;
    
                        tr.addEventListener("click", (e)=>
                        {
                            //window.open("file:///" + element.filePath);
                            // window.open(`${element.filePath}`);
                        })
    
                        tbody.append(tr);
                        table.append(tbody);
                });
            }).catch(data =>
                {
                    if (!data.ok)
                    {
                        UpdateInfo();
                    }
                });
        }else{
            UpdateInfo();
        }
        
    }


    async function UpdateInfo()
    {
        let trTable = table.querySelectorAll(".TrInfo");
                    if (trTable.length > 0)
                    {
                        await trTable.forEach(element =>
                        {
                            element.remove();
                        })
                    }
    }

    
    async function Server (text)
    {
        let res = await fetch(`http://127.0.0.1:5191/api/weatherforecast?model=${text}`,{
            method: "POST",
            });
            if (!res.ok)
            {
                throw new Error("404")
            }

            return await res.text();
    }

});
