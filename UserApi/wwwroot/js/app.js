class LoadingSpinner extends React.Component {
    render() {
        return (
            <span className='loading-spinner-container'>
                <div className='loading-spinner' />
            </span>
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

    handleSubmit(event) {
        event.preventDefault()
        this.props.handleSearchClick(this.state.search)
    }

    render() {
        return (
            <span className='search-container'>
                <form className='search' onSubmit={ this.handleSubmit.bind(this) }>
                    <input type='text' className='search-text' onChange={this.handleChange.bind(this)} value={ this.state.search }/>
                    <button type='submit' className='search-button'>Search</button>
                </form>
                <button onClick={() => this.props.handleSlowSearchClick(this.state.search)} className='search-button'>Slow Search</button>
            </span>
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
        loading: false,
        persons: [],
    }

    loadUsers() {
        this.setState((prevState, props) => ({ loading: true, persons: prevState.persons }))
        axios.get(baseUrl)
            .then(res => this.setState({ loading: false, persons : res.data }))
    }

    searchUsers(search) {
        this.setState((prevState, props) => ({ loading: true, persons: prevState.persons }))
        if (search) {
            axios.get(baseUrl + '/search?search=' + search)
                .then(res => this.setState({ loading: false, persons : res.data }))
        } else {
            this.loadUsers()
        }
    }

    searchUsersDelay(search) {
        this.setState((prevState, props) => ({ loading: true, persons: prevState.persons }))
        axios.get(baseUrl + '/search?search=' + search + '&wait=10')
            .then(res => this.setState({ loading: false, persons: res.data }))
    }

    componentDidMount() {
        this.loadUsers()
    }

    render() {
        return (
            <div className='home'>
                <Search handleSearchClick={this.searchUsers.bind(this)} handleSlowSearchClick={this.searchUsersDelay.bind(this)} />
                { this.state.loading ? <LoadingSpinner /> : null }
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