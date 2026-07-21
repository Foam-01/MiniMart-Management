function MyComponent(props) {
    return (
        <>
            <div>{props.title}</div>
            <div>{props.name}</div>
            <p style={{ backgroundColor: 'red',padding: '10px'}}> 
                {props.children}
            </p>
                
        </>
    )
}

export default MyComponent;