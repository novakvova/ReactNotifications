import React, { Component } from 'react';
import classnames from 'classnames';
import axios from 'axios';
import './Modal.css';
import Notifications from '../components/Notifications/index';

class AxiosUsers extends Component {
    state = { 
        loading: true,
        list: []
    }
    componentDidMount = () => {
        console.log('---componentDidMount---');
        const url='/api/users';
        axios.get(url).then(
            res => {
                console.log('----Axios good----', res);
                this.setState({list: res.data, loading: false})
            },
            err => {
                console.log('----Error upload data----', err.response.data);
            }
        )
    }
    render() {
        console.log('-----this.state------', this.state);
        const {loading, list} = this.state;
        const content = list.map(user => {
            console.log('-----map users-----', user);
            return <li key={user.id}>{user.email}</li>
        });
        return (
            <div>
                <h1>
                    Axios Users Component
                </h1>
                <Notifications />
                <ul>
                    {content}
                </ul>
                <div className={classnames('modal', { 'open': loading })}>
                    <div className="position-center">
                        <i className="fa fa-spinner fa-pulse fa-3x fa-fw"></i>
                        <span className="sr-only">Loading...</span>
                    </div>
                </div>
            </div>
        );
    }
}
 
export default AxiosUsers;