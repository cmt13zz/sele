const BTN_USER = 'button[title="Your personal menu button"]'
const BTN_PROFILE = '//a[text()="View profile"]'

export const HomePage = {
    visitProfilePage() {
        cy.visit('/')
        cy.get(BTN_USER).click()
        cy.xpath(BTN_PROFILE).click()
    }
}

