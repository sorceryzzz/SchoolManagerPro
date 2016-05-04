$.validator.prototype.checkForm = function() {
	//overriden in a specific page
	this.prepareForm();
	for ( var i = 0, elements = (this.currentElements = this.elements()); elements[i]; i++) {
		if (this.findByName(elements[i].name).length != undefined
				&& this.findByName(elements[i].name).length > 1) {
			for ( var cnt = 0; cnt < this.findByName(elements[i].name).length; cnt++) {
				this.check(this.findByName(elements[i].name)[cnt]);
			}
		} else {
			this.check(elements[i]);
		}
	}
	return this.valid();
};