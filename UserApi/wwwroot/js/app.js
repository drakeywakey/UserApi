const baseUrl = 'https://localhost:5001/api/user'

class Person extends React.Component {

    render() {
        const { firstName, lastName } = this.props.person
        return (
            <li>{firstName + ' ' + lastName}</li>
        )
    }

}

class Search extends React.Component {

    state = {
        search: ''
    }

    handleChange(event) {
        this.setState({
            search : event.target.value
        })
    }

    render() {
        return (
            <div>
                <input onChange={this.handleChange.bind(this)} value={ this.state.search }/>
                <button onClick={ () => this.props.handleClick(this.state.search) }>Search!</button>
            </div>
        )
    }
}

class Home extends React.Component {

    state = {
        persons: [],
    }

    loadUsers() {
        axios.get(baseUrl)
            .then(res => this.setState({ persons : res.data }))
    }

    searchUsers(search) {
        if (search) {
            axios.get(baseUrl + '/search?search=' + search)
                .then(res => this.setState({ persons : res.data }))
        } else {
            this.loadUsers()
        }
    }

    componentDidMount() {
        this.loadUsers()
    }

    render() {
        return (
            <div>
                <Search handleClick={this.searchUsers.bind(this)} />
                <ul>
                    { this.state.persons.map(person => <Person key={ person.id } person={ person } />) }
                </ul>
            </div>
        )
    }
}

ReactDOM.render(
    <Home />,
    document.getElementById('root')
)