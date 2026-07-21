import MyComponent from "../shared/components/MyComponent";

function MyLoop() {
    const arr = ['java', 'php', 'c#', 'c/c++', 'python']

    return (
        <>
            <div>Data in arr variable</div>
            {arr.length >= 5 && <div> length is 5</div>}
            {arr.map((item,index) => (
                <div key={item}>{index}:{item}</div>
            ))}
            <MyComponent title = 'my title' name= 'Foam' > 
               <button>My Button</button>
               
            </MyComponent>
        </>
    )
}

export default MyLoop;