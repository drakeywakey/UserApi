class Home extends React.Component {

    state = {
        persons: []
    }

    componentDidMount() {
        axios.get('https://localhost:5001/api/user')
            .then(res => {
                const persons = res.data
                this.setState({ persons })
            })
    }

    render() {
        return (
            <ul>
                { this.state.persons.map(person => <li key={ person.id }>{ person.firstName }</li>) }
            </ul>
        )
    }
}

ReactDOM.render(
    <Home />,
    document.getElementById('root')
)