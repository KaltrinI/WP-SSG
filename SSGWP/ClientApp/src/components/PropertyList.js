import React, { Component } from 'react';
import { Property } from '../components/Property';
import authService from './api-authorization/AuthorizeService'

export class PropertyList extends Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.state = { image: props.image };

    }
    render() {

        return this.renderList();
    }
    async handleSubmit(event) {
        event.preventDefault();
        var elements = document.getElementById("myForm").elements;
        var obj = {};
        for (var i = 0; i < elements.length; i++) {
            var item = elements.item(i);
            obj[item.name] = item.value;
        }

        await authService.subscribe();
        const token = await authService.getAccessToken();
        var res= await fetch('/api/SampleData/aqua', {
            method: 'POST',
            body: JSON.stringify(obj),
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`,
                'Content-Type':'application/json'
            }
        }).then(async (response) => {
            let text = await response.text();
            const url = window.URL.createObjectURL(new Blob([text]));
            const link = document.createElement('a');
            link.href = url;
            link.setAttribute('download', 'file.html'); //or any other extension
            document.body.appendChild(link);
            link.click();
        });
        
    }

     updatePicture = async () => {
        
        var elements = document.getElementById("myForm").elements;
        var obj = {};
        for (var i = 0; i < elements.length; i++) {
            var item = elements.item(i);
            obj[item.name] = item.value;
        }

        await authService.subscribe();
        const token = await authService.getAccessToken();
        var res = await fetch('/api/SampleData/update/aqua', {
            method: 'POST',
            body: JSON.stringify(obj),
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            }
        });

        let url =await res.text();

        this.setState({ image: url})
    }


    renderList = () => {
        let html=[]
        for (let i = 0; i < this.props.list.length;i++)
            html.push(<Property key={i} property={this.props.list[i]} />)

        return (
            <div>
            <div style={{ display: 'inline-block', width: '50%', paddingRight: '20px' }}>
            <form onSubmit={this.handleSubmit} id="myForm">
                {html}
                <button className="btn btn-primary" type="submit" value="Submit">Submit</button>
                <button className="btn btn-success" type="button" value="Update" onClick={this.updatePicture}>Update</button>
                </form>
                </div>

                <div style={{ display: 'inline-block', width: '50%', height: '60vh' }}>
                    <img src={this.state.image} alt="Preview URL" style={{ objectFit: 'fill', height: '100%' }} />
                </div>
                </div>
            );
    }
}