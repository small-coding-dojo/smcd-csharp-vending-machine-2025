describe('Vending Machine landing page', () => {
  it('shows insert coin', () => {
    cy.visit('http://localhost:3000')
    cy.get('#display').should('contain', 'INSERT COIN')
  })
})