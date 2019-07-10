import React, { Component } from 'react';
import { PropertyList } from '../components/PropertyList';
import authService from './api-authorization/AuthorizeService';

export class Aqua extends Component {
    constructor(props) {
        super(props);
        this.state = { Properties: [], loading: true };
    }

    componentDidMount() {
        this.populateAquaData();
    }

    render() {

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Aqua.renderComp(this.state.Properties);

        return (<div>{contents}</div>);
        

    }

    static renderComp(x) {
        return (
            <PropertyList list={x.Properties._properties} image={x.PreviewUrl} />
        );

    } 

    async populateAquaData() {
        
        await authService.subscribe();
        const token = await authService.getAccessToken();
        const response = await fetch('api/SampleData/aqua', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        console.log(data);
        this.setState({ Properties: data, loading: false });
    }
}