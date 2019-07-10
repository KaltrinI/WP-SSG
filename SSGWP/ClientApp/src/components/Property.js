import React, { Component } from 'react';


export class Property extends Component {
    constructor(props) {
        super(props);
        this.state = {
            name: props.property.Name,
            value: props.property.Value
        };
    }



    render() {
        return this.renderProperty();
    }

    renderProperty = () => {
        if (this.props.property.Type == PropertyType.Text)
            return this.textProperty();
        else
            return this.colorProperty();
    }

    onChange = (e) => {
        this.setState({ value: e.target.Value });
    }

    textProperty = () => {
        return (<div>
            <div style={{ width: '50%', display: 'inline-block', paddingRight: '20px' }}>
                <label style={{ display: 'block', textAlign: 'right' }}>{this.state.name}</label>
            </div>
            <div style={{ width: '50%', display: 'inline-block' }}>
                <input type="text" name={this.props.property.Name} value={this.state.value} onChange={this.onChange} />
            </div>
            </div>);
    }

    colorProperty = () => {
        return (<div>
            <div style={{ width: '50%', display: 'inline-block', paddingRight: '20px' }}>
                <label style={{ display: 'block', textAlign : 'right'}}>{this.state.name}</label>
            </div>
            <div style={{ width: '50%', display: 'inline-block' }}>
                <input type="color" name={this.props.property.Name} value={this.state.value} onChange={this.onChange}/>
            </div>
        </div>);
    }

}

const PropertyType = {
    Text : 0,
    Color : 1
}