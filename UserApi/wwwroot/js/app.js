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
            <div className='search'>
                <input className='search-text' onChange={this.handleChange.bind(this)} value={ this.state.search }/>
                <button className='search-button' onClick={ () => this.props.handleClick(this.state.search) }>Search</button>
            </div>
        )
    }
}

class Person extends React.Component {

    render() {
        const { firstName, lastName, imageSrc, age, address, interests } = this.props.person
        return (
            <li className='person'>
                <img src={imageSrc} className='image' />
                <div className='person-info' >
                    <h3>{ firstName + ' ' + lastName } </h3>
                    <h4>{ age } years old </h4>
                    <h5>Address: { address } </h5>
                    <h5>Interests: { interests } </h5>
                </div>
            </li>
        )
    }

}

const baseUrl = 'https://localhost:5001/api/user'

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
            <div className='home'>
                <Search handleClick={this.searchUsers.bind(this)} />
                <ul className='list'>
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